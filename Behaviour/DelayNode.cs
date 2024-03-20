using Godot;

namespace SadChromaLib.AI.Behaviour;

/// <summary>
/// A decorator node that adds a delay before allowing further processing.
/// </summary>
public sealed partial class DelayNode : DecoratorNode
{
	private float _delay;
	private ulong _lastProcessTime;

	public DelayNode(BehaviourNode target, float delay)
		: base(target)
	{
		_delay = delay;
	}

	public override Result Process(AgentContext context)
	{
		ulong currentTime = Time.GetTicksMsec();
		float timeSinceLastProcess = TimeSince(currentTime, _lastProcessTime);

		if (timeSinceLastProcess < _delay)
			return Result.Failure;

		_lastProcessTime = currentTime;
		return _target.Process(context);
	}

	private static float TimeSince(ulong now, ulong time)
	{
		return (now - time) * 0.01f;
	}
}
