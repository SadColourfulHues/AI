namespace SadChromaLib.AI.StateMachine;

/// <summary>
/// An interface that represents a state in a FSM.
/// </summary>
public interface IState
{

    /// <summary>
    /// Used by the state machine to uniquely identify this state.
    /// </summary>
    string GetStateIdentifier();

    /// Called when this state becomes 'active' </summary>
    void OnEnter(AgentContext context);

    /// <summary> Called per frame when this state is active </summary>
    void OnTick(AgentContext context, float delta);
};