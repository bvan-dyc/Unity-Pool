using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<GameObject> Inventory;
    public GameObject firstSelected;
    public GameObject secondSelected;
    public GameObject weaponSlot;
    private GameObject weaponToEquip;
    public Inventary Inventary;
    // Start is called before the first frame update
    void Start()
    {
        Inventary = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventary>();
        firstSelected = null;
        weaponToEquip = null;
        secondSelected = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (firstSelected == null) {
                firstSelected = Inventory.Find(slot => slot.GetComponent<OverItem>().isInsideBox == true && slot.GetComponent<OverItem>().isEmpty == false);
                if (firstSelected != null) {
                    Color tmpColor = firstSelected.transform.Find("MaskForImage").GetComponent<Image>().color;
                    tmpColor.a = 0.5f;
                    firstSelected.transform.Find("MaskForImage").GetComponent<Image>().color = tmpColor;
                }
            }
            else {
                secondSelected = Inventory.Find(slot => slot.GetComponent<OverItem>().isInsideBox == true && slot.GetComponent<OverItem>().isEmpty == false);
                if (secondSelected != null) 
                    Swap();
                else if (weaponSlot.GetComponent<OverItem>().isInsideBox) {
                    Inventary.Equip(firstSelected.GetComponent<ItemInventory>().item.gameObject);
                } else
                    Inventary.Drop(firstSelected.GetComponent<ItemInventory>().item.gameObject);
                // Color tmpColor = firstSelected.transform.Find("MaskForImage").GetComponent<Image>().color;
                // tmpColor.a = 1f;
                // firstSelected.transform.Find("MaskForImage").GetComponent<Image>().color = tmpColor;
                firstSelected = null;
                secondSelected = null;
            }
        }
        if (Input.GetMouseButtonDown(1)) {
            weaponToEquip = Inventory.Find(slot => slot.GetComponent<OverItem>().isInsideBox == true && slot.GetComponent<OverItem>().isEmpty == false);
            if (weaponToEquip != null) {
                Inventary.Equip(weaponToEquip.GetComponent<ItemInventory>().item.gameObject);
            }
        }
    }
    void Swap() {
        if (firstSelected.GetComponent<ItemInventory>().index >= 0 && secondSelected.GetComponent<ItemInventory>().index >= 0)
            Inventary.putInIndex(firstSelected.GetComponent<ItemInventory>().item.gameObject, secondSelected.GetComponent<ItemInventory>().index);
    }
}
