using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttributeFooter : MonoBehaviour
{
    private Hero   hero;
    private TextMeshProUGUI text;
    void Start() {
        hero = GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>();
        text = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if (hero.GetAttributePoints().ToString() != text.text)
            text.text = hero.GetAttributePoints().ToString();
    }
}
