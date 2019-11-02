using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Popup : MonoBehaviour
{
    public Image    itemImg;
    public TextMeshProUGUI     itemName;
    public TextMeshProUGUI     itemDetails;
    public GameObject  win;
    private Canvas  canvas;
    public Image       scarc;

    void Start() {
        scarc.color = new Color(1f, 1f, 1f, 1f);
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }
    public void EnableCanvas() {
        canvas.enabled = true;
    }
    public void DisableCanvas() {
        canvas.enabled = false;
    }
    public bool CanvasIsEnabled() {
        return canvas.enabled;
    }
    public void SetItemDetails(Sprite sprite, string _itemName, string _itemDetails, Color _color) {
        itemImg.sprite = sprite;
        itemName.text = _itemName;
        itemDetails.text = _itemDetails;
        scarc.color = _color;
    }
}
