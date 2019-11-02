using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OverItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector]public Popup   popUp;
    private ItemInventory   itemInventory;
    private Sprite  sprite;
    private string  itemName;
    private string  itemDetails;
    private Color  itemScarcityColor;
    public bool  isEmpty;
    public bool  isInsideBox;
    void Start()
    {
        popUp = GameObject.FindGameObjectWithTag("PopUp").GetComponent<Popup>();
        isEmpty = true;
        isInsideBox = false;
        itemInventory = GetComponent<ItemInventory>();
    }
    public void SetSprite(Sprite _sprite) {
        isEmpty = false;
        sprite = _sprite;
    }
    public void SetName(string _name) {
        itemName = _name;
    }
    public void SetDetails(string _details) {
        itemDetails = _details;
    }
    public void SetScarcityColor(Color color) {
        itemScarcityColor = color;
    }
    public void OnPointerEnter(PointerEventData eventData)
      {
        isInsideBox = true;
        if(!isEmpty) {
            print("OnMouseEnter");
            popUp.EnableCanvas();
            popUp.SetItemDetails(sprite, itemName, itemDetails, itemScarcityColor);
        }
      }

    public void OnPointerExit(PointerEventData eventData)
    {
        isInsideBox = false;
        print("OnMouseExit");
        if(!isEmpty) {
            popUp.DisableCanvas();
        }
    }

    void OnMouseEnter() {
        isEmpty = false;
        Debug.Log("Selecting item");
        popUp.EnableCanvas();
        popUp.SetItemDetails(sprite, itemName, itemDetails, itemScarcityColor);
    }
    void OnMouseExit() {
        isEmpty = true;
        Debug.Log("Quitting selection item");
        popUp.DisableCanvas();
    }
    void Update()
    {
        if (!isEmpty && popUp.CanvasIsEnabled()) {
            popUp.win.gameObject.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition + (Vector3.up * 5f);
        }
    }
}
