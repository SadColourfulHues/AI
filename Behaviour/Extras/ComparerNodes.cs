using System;

namespace SadChromaLib.AI.Behaviour.Extras;

public enum CompareNodeType
{
    Less,
    LessOrEqual,
    Equal,
    Greater,
    GreaterOrEqual
}

static class CompareNodeUtils
{
    public static bool Evaluate<T>(T a, CompareNodeType type, T b)
        where T: IComparable
    {
        int score = a.CompareTo(b);

        switch (type)
        {
            case CompareNodeType.Less:
                return score < 0;

            case CompareNodeType.LessOrEqual:
                return score <= 0;

            case CompareNodeType.Equal:
                return score == 0;

            case CompareNodeType.Greater:
                return score > 0;

            case CompareNodeType.GreaterOrEqual:
                return score >= 0;

            default:
                return false;
        }
    }
}

/// <summary>
/// A conditional node that compares a context variable to a constant.
/// </summary>
public readonly struct CompareBoolNode: IBehaviourNode
{
    readonly string _key;
    readonly bool _compareValue;

    public CompareBoolNode(string key, bool compareWith)
    {
        _key = key;
        _compareValue = compareWith;
    }

    public Result Process(AgentContext context)
    {
        return IBehaviourNode.FromBool(
            context.ReadBool(_key) == _compareValue
        );
    }
}

/// <summary>
/// A conditional node that compares a context variable to a constant.
/// </summary>
public readonly struct CompareIntNode: IBehaviourNode
{
    readonly string _key;
    readonly int _compareValue;
    readonly CompareNodeType _type;

    public CompareIntNode(string key, CompareNodeType type, int compareWith)
    {
        _key = key;
        _compareValue = compareWith;
        _type = type;
    }

    public Result Process(AgentContext context)
    {
        return IBehaviourNode.FromBool(
            CompareNodeUtils.Evaluate(context.ReadInt(_key), _type, _compareValue)
        );
    }
}

/// <summary>
/// A conditional node that compares a context variable to a constant.
/// </summary>
public readonly struct CompareFloatNode: IBehaviourNode
{
    readonly string _key;
    readonly float _compareValue;
    readonly CompareNodeType _type;

    public CompareFloatNode(string key, CompareNodeType type, float compareWith)
    {
        _key = key;
        _compareValue = compareWith;
        _type = type;
    }

    public Result Process(AgentContext context)
    {
        return IBehaviourNode.FromBool(
            CompareNodeUtils.Evaluate(context.ReadFloat(_key), _type, _compareValue)
        );
    }
}