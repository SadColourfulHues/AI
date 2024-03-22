using System;

namespace SadChromaLib.AI.Behaviour;

/// <summary>
/// A composite node that processes its child nodes until one returns 'Success' or 'Running'.
/// </summary>
public struct SelectorNode: IBehaviourNode
{
	readonly IBehaviourNode[] _children;

	public SelectorNode(params IBehaviourNode[] children) {
		_children = children;
	}

	public Result Process(AgentContext context)
	{
		ReadOnlySpan<IBehaviourNode> children = _children.AsSpan();

		for (int i = 0; i < children.Length; ++ i) {
			Result result = children[i].Process(context);

			if (result == Result.Running || result == Result.Success)
				return result;
		}

		return Result.Failure;
	}
}