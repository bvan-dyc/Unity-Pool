using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCanvas : MonoBehaviour
{
    public KeyCode  key;
    private bool    isActive;
    private Popup   popUp;
    private Canvas canvas;

    void Start() {
        isActive = false;
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        popUp = GameObject.FindGameObjectWithTag("PopUp").GetComponent<Popup>();
    }

    void Update()
    {
        if (!isActive && Input.GetKeyDown(key)) {
            canvas.enabled = true;
            isActive = true;
            // Debug.Log("Display canvas");
        }
        else if (Input.GetKeyDown(key)) {
            canvas.enabled = false;
            isActive = false;
            // Debug.Log("Display canvas");
        }
    }
}
