using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisableControlsForUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private UserInput inputManager = null;

    void Start() {
        inputManager = GameObject.FindGameObjectWithTag("InputManager").GetComponent<UserInput>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        inputManager.canControl = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inputManager.canControl = true;
    }
}
