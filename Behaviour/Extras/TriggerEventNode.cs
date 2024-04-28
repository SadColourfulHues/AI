using SadChromaLib.Types;

namespace SadChromaLib.AI.Behaviour.Extras;

/// <summary>
/// An action node that triggers an event in the behaviour tree
/// </summary>
public readonly struct TriggerEventNode: IBehaviourNode
{
    readonly string _eventId;
    readonly AnyData _extraInfo;

    public TriggerEventNode(string eventId)
    {
        _eventId = string.Intern(eventId);
        _extraInfo = AnyData.Empty;
    }

    public TriggerEventNode(string eventId, AnyData extraInfo)
    {
        _eventId = string.Intern(eventId);
        _extraInfo = extraInfo;
    }

    public Result Process(AgentContext context)
    {
        context.TriggerEvent(_eventId, _extraInfo);
        return Result.Success;
    }
}