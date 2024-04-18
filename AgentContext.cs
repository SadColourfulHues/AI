using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

using Godot;

using SadChromaLib.Types;

namespace SadChromaLib.AI;

/// <summary>
/// An object that stores data relevant to information processing for AI agents
/// </summary>
public sealed partial class AgentContext
{
	private Dictionary<string, ContextData> _state;

	public AgentContext() {
		_state = new();
	}

	/// <summary>
	/// Writes an AnyData into the context. (Only value types are supported!)
	/// </summary>
	public void Write(string key, AnyData data)
	{
		switch (data.DataType)
		{
			case AnyData.Type.Bool:
				_state[key] = new(data.BoolValue);
				break;

			case AnyData.Type.Int:
				_state[key] = new(data.IntValue);
				break;

			case AnyData.Type.Float:
				_state[key] = new(data.X);
				break;

			case AnyData.Type.Vector2:
				_state[key] = new(data.AsV2());
				break;

			case AnyData.Type.Vector3:
				_state[key] = new(data.AsV3());
				break;

			case AnyData.Type.Colour:
				_state[key] = new(data.AsColour());
				break;

			default:
				#if TOOLS
				GD.PrintErr($"AgentContext: context cannot store AnyData of type \"{data.DataType}\"");
				#endif
			break;
		}
	}

	/// <summary>
	/// Writes a boolean value into the context.
	/// </summary>
	public void Write(string key, bool data) { _state[key] = new(data); }

	/// <summary>
	/// Writes an integer into the context.
	/// </summary>
	public void Write(string key, int data) { _state[key] = new(data); }

	/// <summary>
	/// Writes a character into the context.
	/// </summary>
	public void Write(string key, char data) { _state[key] = new(data); }

	/// <summary>
	/// Writes a float into the context.
	/// </summary>
	public void Write(string key, float data) { _state[key] = new(data); }

	/// <summary>
	/// Writes a Vector2 into the context.
	/// </summary>
	public void Write(string key, Vector2 data) { _state[key] = new(data); }

	/// <summary>
	/// Writes a Vector3 into the context.
	/// </summary>
	public void Write(string key, Vector3 data) { _state[key] = new(data); }

	/// <summary>
	/// Writes a Color into the context.
	/// </summary>
	public void Write(string key, Color data) { _state[key] = new(data); }

	/// <summary>
	/// Reads a boolean value from the context.
	/// </summary>
	/// <returns></returns>
	public bool ReadBool(string key, bool defaultValue = default)
	{
		if (!_state.ContainsKey(key) || _state[key].DataType != ContextDataType.Bool)
			return defaultValue;

		return _state[key].BoolValue;
	}

	/// <summary>
	/// Reads an integer value from the context.
	/// </summary>
	/// <returns></returns>
	public int ReadInt(string key, int defaultValue = default)
	{
		if (!_state.ContainsKey(key) || _state[key].DataType != ContextDataType.Int)
			return defaultValue;

		return _state[key].IntValue;
	}

	/// <summary>
	/// Reads a float value from the context.
	/// </summary>
	/// <returns></returns>
	public float ReadFloat(string key, float defaultValue = default)
	{
		if (!_state.ContainsKey(key) || _state[key].DataType != ContextDataType.Float)
			return defaultValue;

		return _state[key].X;
	}

	/// <summary>
	/// Reads a Vector2 from the context.
	/// </summary>
	/// <returns></returns>
	public Vector2 ReadV2(string key, Vector2 defaultValue = default)
	{
		if (!_state.ContainsKey(key) || _state[key].DataType != ContextDataType.Vector2)
			return defaultValue;

		return _state[key].AsV2();
	}

	/// <summary>
	/// Reads a Vector3 from the context.
	/// </summary>
	/// <returns></returns>
	public Vector3 ReadV3(string key, Vector3 defaultValue = default)
	{
		if (!_state.ContainsKey(key) || _state[key].DataType != ContextDataType.Vector3)
			return defaultValue;

		return _state[key].AsV3();
	}

	/// <summary>
	/// Reads a Color from the context.
	/// </summary>
	/// <returns></returns>
	public Color ReadColour(string key, Color defaultValue = default)
	{
		if (!_state.ContainsKey(key) || _state[key].DataType != ContextDataType.Colour)
			return defaultValue;

		return _state[key].AsColour();
	}

	/// <summary>
	/// Writes a stored boolean value to 'target' and returns true if the specified
	/// item exists in the context.
	/// </summary>
	/// <returns></returns>
	public bool TryReadBool(string key, out bool target)
	{
		if (!_state.TryGetValue(key, out ContextData data)) {
			target = default;
			return false;
		}

		bool matchesType = data.DataType == ContextDataType.Bool;

		target = matchesType ? data.BoolValue : default;
		return matchesType;
	}

	/// <summary>
	/// Writes a stored integer value to 'target' and returns true if the specified
	/// item exists in the context.
	/// </summary>
	/// <returns></returns>
	public bool TryReadInt(string key, out int target)
	{
		if (!_state.TryGetValue(key, out ContextData data)) {
			target = default;
			return false;
		}

		bool matchesType = data.DataType == ContextDataType.Int;

		target = matchesType ? data.IntValue : default;
		return matchesType;
	}

	/// <summary>
	/// Writes a stored float value to 'target' and returns true if the specified
	/// item exists in the context.
	/// </summary>
	/// <returns></returns>
	public bool TryReadFloat(string key, out float target)
	{
		if (!_state.TryGetValue(key, out ContextData data)) {
			target = default;
			return false;
		}

		bool matchesType = data.DataType == ContextDataType.Float;

		target = matchesType ? data.X : default;
		return matchesType;
	}

	/// <summary>
	/// Writes a stored Vector2 value to 'target' and returns true if the specified
	/// item exists in the context.
	/// </summary>
	/// <returns></returns>
	public bool TryReadV2(string key, out Vector2 target)
	{
		if (!_state.TryGetValue(key, out ContextData data)) {
			target = default;
			return false;
		}

		bool matchesType = data.DataType == ContextDataType.Vector2;

		target = matchesType ? data.AsV2() : default;
		return matchesType;
	}

	/// <summary>
	/// Writes a stored boolean value to 'target' and returns true if the specified
	/// item exists in the context.
	/// </summary>
	/// <returns></returns>
	public bool TryReadV3(string key, out Vector3 target)
	{
		if (!_state.TryGetValue(key, out ContextData data)) {
			target = default;
			return false;
		}

		bool matchesType = data.DataType == ContextDataType.Vector3;

		target = matchesType ? data.AsV3() : default;
		return matchesType;
	}

	/// <summary>
	/// Writes a stored colour value to 'target' and returns true if the specified
	/// item exists in the context.
	/// </summary>
	/// <returns></returns>
	public bool TryReadColour(string key, out Color target)
	{
		if (!_state.TryGetValue(key, out ContextData data)) {
			target = default;
			return false;
		}

		bool matchesType = data.DataType == ContextDataType.Colour;

		target = matchesType ? data.AsColour() : default;
		return matchesType;
	}

	/// <summary>
	/// Erases a data from the context.
	/// </summary>
	/// <param name="key"></param>
	public void Remove(string key) {
		_state.Remove(key);
	}

	/// <summary>
	/// Checks if a key exists in the context.
	/// </summary>
	/// <param name="key"></param>
	/// <returns></returns>
	public bool HasKey(string key) {
		return _state.ContainsKey(key);
	}

	/// <summary>
	/// Removes all data from the context.
	/// </summary>
	public void Reset() {
		_state.Clear();
	}

	#region Storage Helpers

	enum ContextDataType: byte
	{
		Bool = 1,
		Int = 2,
		Float = 3,
		Vector2 = 4,
		Vector3 = 5,
		Colour = 6
	}

	/// <summary>
	/// A union holding value types stored in an agent context
	/// </summary>
	[StructLayout(LayoutKind.Explicit)]
	private struct ContextData
	{
		[FieldOffset(0)]
		public bool BoolValue;

		[FieldOffset(0)]
		public int IntValue;

		[FieldOffset(0)]
		public float X;

		[FieldOffset(4)]
		public float Y;

		[FieldOffset(8)]
		public float Z;

		[FieldOffset(12)]
		public byte A;

		[FieldOffset(13)]
		public ContextDataType DataType;

		public ContextData(bool value) : this() { BoolValue = value; DataType = ContextDataType.Bool; }
		public ContextData(int value) : this() { IntValue = value; DataType = ContextDataType.Int; }
		public ContextData(float value) : this() { X = value; DataType = ContextDataType.Float; }

		public ContextData(Vector2 v) : this()
		{
			X = v.X;
			Y = v.Y;

			DataType = ContextDataType.Vector2;
		}

		public ContextData(Vector3 v) : this()
		{
			X = v.X;
			Y = v.Y;
			Z = v.Z;

			DataType = ContextDataType.Vector3;
		}

		public ContextData(Color v) : this()
		{
			X = v.R;
			Y = v.G;
			Z = v.B;
			A = (byte) Mathf.Floor(255f * v.A);

			DataType = ContextDataType.Colour;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly Vector2 AsV2() { return new(X, Y); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly Vector3 AsV3() { return new(X, Y, Z); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly Color AsColour() { return new(X, Y, Z, (float)A/255f); }
	}

	#endregion
}