using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackground : MonoBehaviour {
	private Color whiteGreen = new Color32(84, 255, 46, 255);
	private Color cyan = Color.cyan;
	private float duration = 3.0F;
	private Camera cam;

	void Start () {
		cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
	}

	void Update () {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        cam.backgroundColor = Color.Lerp(cyan, whiteGreen, t);
	}
}
