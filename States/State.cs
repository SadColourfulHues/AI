namespace SadChromaLib.AI.StateMachine;

/// <summary>
/// An interface that represents a state in a FSM.
/// </summary>
public interface IState
{
    public const string GenericId = "state";

    /// <summary>
    /// Used by the state machine to uniquely identify this state.
    /// </summary>
    virtual string Identifier
        => GenericId;

    /// Called when this state becomes 'active' </summary>
    virtual void OnEnter(AgentContext context) {}

    /// <summary> Called per frame when this state is active </summary>
    virtual void OnTick(AgentContext context, float delta) {}
};