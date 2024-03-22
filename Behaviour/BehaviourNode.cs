using Godot;

namespace SadChromaLib.AI.Behaviour;

/// <summary>
/// The output of a behaviour node.
/// </summary>
public enum Result
{
	Running,
	Success,
	Failure
}

/// <summary>
/// An interface that represents behaviour node.
/// </summary>
public interface IBehaviourNode
{
	public Result Process(AgentContext context);
}
