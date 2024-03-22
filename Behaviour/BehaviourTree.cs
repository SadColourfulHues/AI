using Godot;

namespace SadChromaLib.AI.Behaviour;

/// <summary>
/// An evaluator that relies on behaviour nodes to determine an agent's next course of action.
/// </summary>
public sealed partial class BehaviourTree : RefCounted
{
	private IBehaviourNode _root;
	private AgentContext _context;

	public BehaviourTree(IBehaviourNode root)
	{
		_root = root;
		_context = new();
	}

	public void SetRoot(IBehaviourNode root)
	{
		_root = root;
	}

	public void Process()
	{
		_root.Process(_context);
	}

	public AgentContext GetContext()
	{
		return _context;
	}
}