using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    #region Lifecycle
    protected void Awake()
    {
        _fsm = new PlayerFSM(this);
        input = new InputActions();
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        //TODO: start as idle and wait for level to set to active state
        _fsm.goToState(_fsm.activeState);
        input.Enable();
    }

    private void Update()
    {
        _fsm.currentState?.Update();
    }
    #endregion

    #region Properties
    public float movementSpeed = 1;
    public float rotationSpeed = 0.1f;
    #endregion

    #region FSM
    protected PlayerFSM _fsm;
    #endregion

    #region Input
    public InputActions input;
    #endregion

    #region Controller
    [HideInInspector]
    public CharacterController characterController;
    #endregion

    #region Model
    public Transform model;
    #endregion
}