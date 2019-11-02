using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventary : MonoBehaviour
{
    public List<GameObject> ownedItems;
    public GameObject equipedWeapon;
    private GameObject player;
    private List<GameObject> spawnedItems;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnedItems = GameObject.FindGameObjectWithTag("ItemList").GetComponent<ItemList>().spawnedItems;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y) == true && ownedItems[0] != null)
            Equip(ownedItems[0]);
        if (Input.GetKeyDown(KeyCode.U) == true && equipedWeapon != null)
            Unequip();
        if (Input.GetKeyDown(KeyCode.Q) == true && ownedItems[0] != null)
            Drop(ownedItems[0]);
    }
    public void PickUp(GameObject obj) {
        Item item = obj.GetComponent<Item>();
        if (ownedItems.Count < 12) {
            ownedItems.Add(obj);
            obj.SetActive(false);
            // obj.hideFlags = HideFlags.HideInHierarchy;
        }
    }
    public void Equip(GameObject obj) {
        if (equipedWeapon != null)
            Unequip();
        Item item = obj.GetComponent<Item>();
        if (item.isEquiped == false && equipedWeapon == null) {
            obj.SetActive(true);
            // obj.hideFlags = HideFlags.None;
            item = obj.GetComponent<Item>();
            item.isEquiped = true;
            obj.transform.SetParent(GameObject.FindGameObjectWithTag("rightHand").transform);
            obj.transform.localPosition = new Vector3(0, 0, 0);
            obj.transform.localEulerAngles = new Vector3(180, 0, 90);
            equipedWeapon = obj;
            ownedItems.Remove(obj);
			player.GetComponent<Hero>().Equip(item);
        }
    }
    public void Unequip() {
        Item item = equipedWeapon.GetComponent<Item>();
        if (item.isEquiped == true) {
            item.isEquiped = false;
            ownedItems.Add(equipedWeapon);
            equipedWeapon.SetActive(false);
            // equipedWeapon.hideFlags = HideFlags.HideInHierarchy;
            equipedWeapon = null;
			player.GetComponent<Hero>().Unequip(item);
		}
    }
    public void Drop(GameObject obj) {
        // obj.hideFlags = HideFlags.None;
        obj.SetActive(true);
        obj.transform.position = player.transform.position;
        obj.GetComponent<Item>().hasBeenDrop = true;
        GeometryExtensions.SetPositionY(obj.transform, obj.transform.position.y + 0.3f);
        ownedItems.Remove(obj);   
    }
    public void putInIndex(GameObject current, int index) {
        ownedItems.Remove(current);
        ownedItems.Insert(index, current);
    }
}
