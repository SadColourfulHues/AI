using Godot;

namespace SadChromaLib.AI.Behaviour;

public enum Result
{
	Running,
	Success,
	Failure
}

/// <summary>
/// The base class of all behaviour nodes.
/// </summary>
public abstract partial class BehaviourNode : RefCounted
{
	public abstract Result Process(AgentContext context);
}
