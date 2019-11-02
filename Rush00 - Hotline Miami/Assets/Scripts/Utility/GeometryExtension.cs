using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GeometryExtensions
{
	public static void SetPositionX(this Transform t, float newX)
	{
		t.position = new Vector3(newX, t.position.y, t.position.z);
	}

	public static void SetPositionY(this Transform t, float newY)
	{
		t.position = new Vector3(t.position.x, newY, t.position.z);
	}

	public static void SetPositionZ(this Transform t, float newZ)
	{
		t.position = new Vector3(t.position.x, t.position.y, newZ);
	}

	public static void SetPosition2D(this Transform t, float x, float y)
	{
		t.position = new Vector3(x, y, t.position.z);
	}

	public static void SetPosition2D(this Transform t, Vector2 position)
	{
		t.position = new Vector3(position.x, position.y, t.position.z);
	}

	public static void SetPosition3D(this Transform t, float x, float y, float z)
	{
		t.position = new Vector3(x, y, z);
	}

	public static void SetScaleX(this Transform t, float newXScale)
	{
		t.localScale = new Vector3(newXScale, t.localScale.y, t.localScale.z);
	}

	public static void SetScaleY(this Transform t, float newYScale)
	{
		t.localScale = new Vector3(t.localScale.x, newYScale, t.localScale.z);
	}

	public static void SetScaleZ(this Transform t, float newZScale)
	{
		t.localScale = new Vector3(t.localScale.x, t.localScale.y, newZScale);
	}

	public static void SetRotationZ(this Transform t, float newZRotation)
	{
		t.localEulerAngles = new Vector3(t.localEulerAngles.x, t.localEulerAngles.y, newZRotation);
	}

	public static void SetScaleMatching(this Transform t, float newScale)
	{
		t.localScale = new Vector3(newScale, newScale, newScale);
	}

	public static float GetPositionX(this Transform t)
	{
		return t.position.x;
	}

	public static float GetPositionY(this Transform t)
	{
		return t.position.y;
	}

	public static float GetPositionZ(this Transform t)
	{
		return t.position.z;
	}

	public static float GetScaleX(this Transform t)
	{
		return t.localScale.x;
	}

	public static float GetScaleY(this Transform t)
	{
		return t.localScale.y;
	}

	public static float GetScaleZ(this Transform t)
	{
		return t.localScale.z;
	}

	public static float GetRotation2D(this Transform t)
	{
		return t.localEulerAngles.z;
	}

	public static void SetRotation2D(this Transform t, float rotation)
	{
		Vector3 eulerAngles = t.eulerAngles;
		eulerAngles.z = rotation;
		t.eulerAngles = eulerAngles;
	}
}
