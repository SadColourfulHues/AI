using Godot;
using System;

namespace SadChromaLib.AI.StateMachine;

/// <summary>
/// Base class that represents a state in a FSM.
/// </summary>
public class BaseState
{
    public static StringName GenericId = "state";

    /// <summary>
    /// Used by the state machine to uniquely identify this state.
    /// </summary>
    public virtual StringName Identifier
        => GenericId;

    /// Called when this state becomes 'active' </summary>
    public virtual void OnEnter(AgentContext context) {}

    /// <summary> Called per frame when this state is active </summary>
    public virtual void OnTick(AgentContext context, float delta) {}
};