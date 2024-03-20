namespace SadChromaLib.AI.Behaviour;

/// <summary>
/// A decorator that inverts the result of its wrapped node.
/// </summary>
public partial class InverterNode : DecoratorNode
{
	public InverterNode(BehaviourNode node)
		: base(node)
	{
	}

	public override Result Process(AgentContext context)
	{
		return Invert(_target.Process(context));
	}

	public static Result Invert(Result result)
	{
		if (result == Result.Running)
			return result;

		return result == Result.Success ?
			Result.Failure : Result.Success;
	}
}
