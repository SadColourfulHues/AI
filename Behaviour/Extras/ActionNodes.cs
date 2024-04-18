using SadChromaLib.Types;

namespace SadChromaLib.AI.Behaviour.Extras;

/// <summary>
/// An action node that writes a flag (bool) into the context.
/// (For most use-cases, prefer this over SetVariableNode as its writing process is way faster.)
/// </summary>
public readonly struct SetFlagNode: IBehaviourNode
{
    readonly string _key;

    public SetFlagNode(string key) {
        _key = key;
    }

    public Result Process(AgentContext context)
    {
        context.Write(_key, true);
        return Result.Success;
    }
}

/// <summary>
/// An action node that writes a value into the context when ran
/// </summary>
public readonly struct SetVariableNode: IBehaviourNode
{
    readonly string _key;
    readonly AnyData _value;

    public SetVariableNode(string key, AnyData value)
    {
        _key = key;
        _value = value;
    }

    public Result Process(AgentContext context)
    {
        context.Write(_key, _value);
        return Result.Success;
    }
}