public class PlayerFSM : FSM<Player>
{
    #region Constructor
    public PlayerFSM(Player owner) : base(owner)
    {
        _createStates();
        _connectStates();
    }
    #endregion

    #region States
    public PlayerStateIdle idleState;
    public PlayerStateActive activeState;
    #endregion

    #region Create States
    private void _createStates()
    {
        idleState = new PlayerStateIdle(this);
        activeState = new PlayerStateActive(this);
    }
    #endregion

    #region Connect States
    private void _connectStates()
    {
        //e.g. nameState.onEventName = this.otherState
    }
    #endregion
}