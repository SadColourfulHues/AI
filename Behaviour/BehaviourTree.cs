using SadChromaLib.Types;

namespace SadChromaLib.AI.Behaviour;

/// <summary>
/// An evaluator that relies on behaviour nodes to determine an agent's next course of action.
/// </summary>
public sealed partial class BehaviourTree
{
	public event AgentContext.EventCallbackDelegate OnEvent;

	private IBehaviourNode _root;
	private AgentContext _context;

	public BehaviourTree(IBehaviourNode root)
	{
		_root = root;
		_context = new();
		_context.EventHandler = OnContextEvent;
	}

	#region Main Functions

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

	#endregion

	#region Events

	private void OnContextEvent(string id, AnyData info) {
		OnEvent?.Invoke(id, info);
	}

	#endregion
}