using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public GameObject smoke;
    public HintManager hint;
    public bool disableHint = false;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!disableHint)
                hint.displayHint("Press E to activate the fan");
            disableHint = true;
        }
    }
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.E)){
            smoke.SetActive(true);
        }
    }
}
