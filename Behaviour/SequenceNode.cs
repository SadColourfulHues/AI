namespace SadChromaLib.AI.Behaviour;

/// <summary>
/// A composite node that processes its child nodes until one returns 'Failure' or 'Running'.
/// </summary>
public partial class SequenceNode: CompositeNode
{
	public SequenceNode(params BehaviourNode[] children)
		: base(children)
	{
	}

	public override Result Process(AgentContext context)
	{
		for (int i = 0; i < _children.Count; ++ i) {
			Result result = _children[i].Process(context);

			if (result == Result.Running || result == Result.Failure)
				return result;
		}

		return Result.Success;
	}
}