using UnityEngine;

public class Player : MonoBehaviour
{
    #region Lifecycle
    protected void Awake()
    {
        _fsm = new PlayerFSM(this);
    }

    private void Start()
    {
        //TODO: start as idle and wait for level to set to active state
        _fsm.goToState(_fsm.activeState);
    }

    private void Update()
    {
        _fsm.currentState?.Update();
    }
    #endregion

    #region FSM
    protected PlayerFSM _fsm;
    #endregion
}