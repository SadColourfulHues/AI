namespace SadChromaLib.AI.Behaviour;

/// <summary>
/// A decorator that inverts the result of its wrapped node.
/// </summary>
public struct InverterNode: IBehaviourNode
{
	IBehaviourNode _target;

	public InverterNode(IBehaviourNode node) {
		_target = node;
	}

	public Result Process(AgentContext context) {
		return IBehaviourNode.Invert(_target.Process(context));
	}
}
