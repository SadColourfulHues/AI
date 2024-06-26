using Godot;
using System.Collections.Generic;

namespace SadChromaLib.AI.StateMachine;

/// <summary>
/// An evaluator that processes an agent's actions through the use of states.
/// </summary>
public sealed partial class StateMachine
{
    public delegate void StateChangedEventHandler(string stateId);
    AgentContext _context;

    Dictionary<string, IState> _states;
    IState _activeState;

    public StateMachine(int maxStates = 8)
    {
        _states = new(maxStates);
        _context = new();

        _activeState = null;
    }

    public void Process(float delta) {
        _activeState?.OnTick(_context, (float) delta);
    }

    #region Main Functions

    /// <summary>
    /// Returns the state machine's agent context
    /// </summary>
    /// <returns></returns>
    public AgentContext GetContext() {
        return _context;
    }

    /// <summary>
    /// Adds a state to the state machine
    /// </summary>
    /// <param name="state"></param>
    public void Add<T>(T state)
        where T: struct, IState
    {
        string id = state.GetStateIdentifier();

        if (_states.ContainsKey(id))
            return;

        _states[id] = state;
    }

    /// <summary>
    /// Sets the active state by ID
    /// </summary>
    public void Set(string id)
    {
        if (!_states.TryGetValue(id, out IState state)) {
            _activeState = null;
            return;
        }

        _activeState = state;
        _activeState?.OnEnter(_context);
    }

    #endregion
}