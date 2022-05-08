using UnityEngine;

public class PlayerStateActive : FSMState<Player>
{
    #region Constructors
    public PlayerStateActive(FSM<Player> fsm) : base(fsm) {}
    #endregion

    #region Lifecycle
    public override void Update()
    {
        base.Update();

        //grab input
        var inputValue = owner.input.Game.Move.ReadValue<Vector2>();

        //calculate movement
        var cameraRight = Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up);
        var cameraForward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up);

        var moveX = cameraRight * inputValue.x;
        var moveY = cameraForward * inputValue.y;

        var movement = moveX + moveY;
        movement *= owner.movementSpeed * Time.deltaTime;

        //calculate rotation
        if (movement.magnitude > 0.01f)
            _lookRotation = Quaternion.LookRotation(movement, Vector3.up);

        owner.model.rotation = Quaternion.Slerp(owner.model.rotation, _lookRotation, owner.rotationSpeed);

        //calculate gravity
        if (!owner.characterController.isGrounded)
        {
            _lastGravityVelocity += Physics.gravity.y * Time.deltaTime;
            movement = new Vector3(movement.x, _lastGravityVelocity, movement.z);
        }
        else _lastGravityVelocity = 0;

        //apply movement
        owner.characterController.Move(movement);
    }
    #endregion

    #region Properties
    private float _lastGravityVelocity;
    private Quaternion _lookRotation;
    #endregion
}