using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject spawnPoint;
    public ParticleSystem particle;
    void Start() {
        if (particle)
            particle.Play();
    }
    void OnTriggerEnter(Collider Col) {
        if (Col.gameObject.tag == "Player") {
            Col.gameObject.transform.position = spawnPoint.transform.position;
        }
    }
}
