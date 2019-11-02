using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMana : MonoBehaviour
{
    public int manaAmmount = 30;
    private GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider Col) {
        if (Col.gameObject.tag == "Player") {
            player.GetComponent<ManaPool>().GainMana(manaAmmount);
            Destroy(gameObject);
        }
    }
}
