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

        
    }
    #endregion
}