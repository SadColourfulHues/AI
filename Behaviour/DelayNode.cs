using Godot;

namespace SadChromaLib.AI.Behaviour;

/// <summary>
/// A decorator node that adds a delay before allowing further processing.
/// </summary>
public struct DelayNode: IBehaviourNode
{
	readonly IBehaviourNode _target;

	readonly float _delay;
	ulong _lastProcessTime;

	public DelayNode(IBehaviourNode node, float delay = 0.25f)
	{
		_target = node;

		_delay = delay;
		_lastProcessTime = 0;
	}

	public Result Process(AgentContext context)
	{
		ulong currentTime = Time.GetTicksMsec();
		float timeSinceLastProcess = TimeSince(currentTime, _lastProcessTime);

		if (timeSinceLastProcess < _delay)
			return Result.Failure;

		_lastProcessTime = currentTime;
		return _target.Process(context);
	}

	private static float TimeSince(ulong now, ulong time) {
		return (now - time) * 0.01f;
	}
}
