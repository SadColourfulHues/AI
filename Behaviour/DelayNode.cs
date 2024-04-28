using SadChromaLib.Utils.Timing;

namespace SadChromaLib.AI.Behaviour;

/// <summary>
/// A decorator node that adds a delay before allowing further processing.
/// </summary>
public struct DelayNode: IBehaviourNode
{
	readonly IBehaviourNode _target;

	readonly float _delay;
	readonly bool _passthrough;
	long _lastProcessTicks;

	public DelayNode(float delay, IBehaviourNode node)
	{
		_target = node;
		_passthrough = false;

		_delay = delay;
		_lastProcessTicks = 0;
	}

	public DelayNode(float delay, bool passthrough, IBehaviourNode node)
		: this(delay, node)
	{
		_passthrough = passthrough;
	}

	public Result Process(AgentContext context)
	{
		long currentTime = TimingUtils.GetTicks();
		float timeSinceLastProcess = (float) TimingUtils.MsecsSince(_lastProcessTicks * TimingUtils.MsecsFac);

		if (timeSinceLastProcess < _delay)
			return (_passthrough ? Result.Success : Result.Failure);

		_lastProcessTicks = currentTime;
		return _target.Process(context);
	}
}
