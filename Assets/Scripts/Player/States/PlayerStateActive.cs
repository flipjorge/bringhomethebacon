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

        var inputValue = owner.input.Game.Move.ReadValue<Vector2>();

        var cameraRight = Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up);
        var cameraForward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up);

        var moveX = cameraRight * inputValue.x;
        var moveY = cameraForward * inputValue.y;

        var movement = moveX + moveY;
        movement *= owner.movementSpeed * Time.deltaTime;

        owner.characterController.Move(movement);
    }
    #endregion
}