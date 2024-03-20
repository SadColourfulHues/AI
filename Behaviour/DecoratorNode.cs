namespace SadChromaLib.AI.Behaviour;

/// <summary>
/// Base class for all decorator nodes. (Nodes that wraps other nodes, injecting functionality into them.)
/// </summary>
public abstract partial class DecoratorNode : BehaviourNode
{
	protected BehaviourNode _target;

	protected DecoratorNode(BehaviourNode target)
	{
		_target  = target;
	}
}
