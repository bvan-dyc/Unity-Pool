using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public int healAmmount = 30;
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
        Debug.Log("COucou");
        if (Col.gameObject.tag == "Player") {
            player.GetComponent<Damageable>().GainHealth(healAmmount);
            Destroy(gameObject);
        }
    }
}
