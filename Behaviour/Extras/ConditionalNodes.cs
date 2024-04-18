namespace SadChromaLib.AI.Behaviour.Extras;

/// <summary>
/// A conditional node that returns true if a boolean value exists in the context
/// </summary>
public readonly struct HasFlagNode: IBehaviourNode
{
    readonly string _flag;

    public HasFlagNode(string flagKey) {
        _flag = flagKey;
    }

	public Result Process(AgentContext context) {
		return IBehaviourNode.FromBool(context.HasKey(_flag));
	}
}
