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

	/// <summary>
	/// Converts a boolean into a Result (Success/Failure).
	/// </summary>
	/// <returns></returns>
	public static Result FromBool(bool condition)
		=> condition ? Result.Success : Result.Failure;

	/// <summary>
	/// Inverts the value of a Result
	/// </summary>
	/// <returns></returns>
	public static Result Invert(Result result)
	{
		return result switch {
			Result.Success => Result.Failure,
			Result.Failure => Result.Success,
			_ => result
		};
	}
}
