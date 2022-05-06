public class FSM<T>
{
    #region Constructors
    public FSM(T owner)
    {
        this._owner = owner;
    }
    #endregion

    #region Owner
    protected T _owner;

    public T owner
    {
        get { return this._owner; }
    }
    #endregion

    #region CurrentState
    private FSMState<T> _currentState;

    public FSMState<T> currentState
    {
        get { return this._currentState; }
    }
    #endregion

    #region Go
    public void goToState(FSMState<T> state)
    {
        if(this._currentState != null) this._currentState.Exit();
        this._currentState = state;
        if(this._currentState != null) this._currentState.Enter();
    }
    #endregion
}