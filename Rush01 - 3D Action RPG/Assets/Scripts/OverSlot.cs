using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OverSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isInsideBox = false;
    public bool isEmpty = true;
    public int  index;
    public Image img;

    public void OnPointerEnter(PointerEventData eventData)
      {
        isInsideBox = true;
        if(!isEmpty) {
            print("OnMouseEnter");
        }
      }

    public void OnPointerExit(PointerEventData eventData)
    {
        isInsideBox = false;
        print("OnMouseExit");
        if(!isEmpty) {
        }
    }
}
