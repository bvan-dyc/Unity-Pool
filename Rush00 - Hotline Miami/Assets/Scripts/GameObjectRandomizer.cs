using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectRandomizer : MonoBehaviour
{
    [SerializeField] private GameObject[] objects = null;

    private void Awake()
    {
        GameObject newObject = Instantiate(objects[Random.Range(0, objects.Length)]);
        newObject.transform.position = transform.position;
    }
}
