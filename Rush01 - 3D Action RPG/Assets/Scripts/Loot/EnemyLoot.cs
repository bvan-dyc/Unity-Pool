using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoot : MonoBehaviour
{
    // Start is called before the first frame update
    public int chanceOfLooting = 50;
    public int rareChance = 20;
    public int veryRareChance = 15;
    public int epicChance = 10;
    public int legendaryChance = 5;
    public ItemList listItem;
    public GameObject player;
    public GameObject PotionPrefab;
    public GameObject PotionMana;
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Loot() {
        listItem = GameObject.FindGameObjectWithTag("ItemList").GetComponent<ItemList>();
        player = GameObject.FindGameObjectWithTag("Player");
        if (Random.Range(0, 101) < chanceOfLooting) {
            LootWeapon();
        }
        else {
            LootPotion();
        }
    }
    void LootWeapon() {
        int loot = Random.Range(0, 101);
        if (loot < legendaryChance)
            Spawn(4);
        else if (loot < epicChance + legendaryChance)
            Spawn(3);
        else if (loot < veryRareChance + epicChance + legendaryChance)
            Spawn(2);
        else if (loot < rareChance + veryRareChance + epicChance + legendaryChance)
            Spawn(1);
        else
            Spawn(0);
    }
    void LootPotion() {
        if (Random.Range(0, 2) == 0)
            Instantiate(PotionPrefab, transform.position, new Quaternion(0,0,0,0));
        else
            Instantiate(PotionMana, transform.position, new Quaternion(0,0,0,0));
    }
    void Spawn(int scarcity) {
        List<GameObject> selectedItems;
        GameObject selectedItem;
        selectedItems = listItem.prefabs.FindAll(prefab => prefab.GetComponent<Item>().scarcity == scarcity);
        selectedItem = Instantiate(selectedItems[Random.Range(0, selectedItems.Count)], transform.position, new Quaternion(0, 0, 0, 0));
        Item item = selectedItem.GetComponent<Item>();
        item.level = player.GetComponent<Hero>().data.level;
        item.attackSpeed = item.attackSpeed + (float)item.level / 100f;
        item.damage = item.damage + item.level;
        listItem.spawnedItems.Add(selectedItem);

    }
}
