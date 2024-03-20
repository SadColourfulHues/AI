using Godot.Collections;

namespace SadChromaLib.AI.Behaviour;

/// <summary>
/// Base class for all composite nodes. (Nodes that stores references to a collection of child nodes.)
/// </summary>
public abstract partial class CompositeNode : BehaviourNode
{
	protected Array<BehaviourNode> _children;

	protected CompositeNode(params BehaviourNode[] children)
	{
		_children = new(children);
	}

	public void Add(BehaviourNode node)
	{
		_children.Add(node);
	}

	public void Remove(BehaviourNode node)
	{
		_children.Remove(node);
	}
}
