using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInventory : MonoBehaviour
{
    public int  index;
    private Inventary  inventory;
    public Item item;
    public Button buttonItem;
    public Image ColorItem;

    private OverItem over;
    void Start()
    {
        baseSlot();
    }

    void SetItem() {
        over.SetSprite(item.Skin);
        over.SetName(item.nameItem);
        // Generate description with damage, dps, description
        ColorItem.color = GetItemColor();
        over.SetDetails("Level: " + item.level + "\n+" + item.damage + " Damage\n+" + item.attackSpeed + " Speed Attack\n" + item.description);
        over.SetScarcityColor(GetItemColor());
        buttonItem.GetComponent<Image>().sprite = item.Skin;
        buttonItem.gameObject.SetActive(true);
    }
    void Update()
    {   
        if (index == -1) {
            if (inventory.equipedWeapon) {
                item = inventory.equipedWeapon.GetComponent<Item>();
                SetItem();
            }
        }
        else if (inventory.ownedItems.Count > index) {
            item = inventory.ownedItems[index].GetComponent<Item>();
            SetItem();
        } else {
            baseSlot();
        }
    }
    Color GetItemColor() {
        Color color;
        if (item.scarcity == 0)
            ColorUtility.TryParseHtmlString("#95a5a6ff", out color);
        else if (item.scarcity == 1)
            ColorUtility.TryParseHtmlString("#27ae60ff", out color);
        else if (item.scarcity == 2)
            ColorUtility.TryParseHtmlString("#2980b9ff", out color);
        else if (item.scarcity == 3)
            ColorUtility.TryParseHtmlString("#8E44ADFF", out color);
        else
            ColorUtility.TryParseHtmlString("#f1c40fff", out color);
        return color;

    }
    void baseSlot() {
        Color color;
        ColorUtility.TryParseHtmlString("#FFFFFF00", out color);
        ColorItem.color = color;
        buttonItem.gameObject.SetActive(false);
        buttonItem.GetComponent<Image>().sprite = null;
        item = null;
        over = GetComponent<OverItem>();
        over.isEmpty = true;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventary>();
    }
}
