namespace SadChromaLib.AI.Behaviour;

/// <summary>
/// A special node type that always returns 'success'
/// </summary>
public struct AlwaysNode : IBehaviourNode
{
	public Result Process(AgentContext context) {
		return Result.Success;
	}
}
