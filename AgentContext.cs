using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

using Godot;

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

	enum ContextDataType
	{
		Bool,
		Int,
		Float,
		Vector2,
		Vector3,
		Colour
	}

	/// <summary>
	/// A union holding possible data stored in a context
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
		public float A;

		[FieldOffset(16)]
		public ContextDataType DataType;

		public ContextData(bool value) : this() { BoolValue = value; DataType = ContextDataType.Bool; }
		public ContextData(int value) : this() { IntValue = value; DataType = ContextDataType.Int; }
		public ContextData(float value) : this() { X = value; DataType = ContextDataType.Float; }
		public ContextData(Vector2 v) : this() { X = v.X; Y = v.Y; DataType = ContextDataType.Vector2; }
		public ContextData(Vector3 v) : this() { X = v.X; Y = v.Y; Z = v.Z; DataType = ContextDataType.Vector3; }
		public ContextData(Color v) : this() { X = v.R; Y = v.G; Z = v.B; A = v.A; DataType = ContextDataType.Colour; }

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly Vector2 AsV2() { return new(X, Y); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly Vector3 AsV3() { return new(X, Y, Z); }
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly Color AsColour() { return new(X, Y, Z, A); }
	}

	#endregion
}