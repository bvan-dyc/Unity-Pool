using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillsFooter : MonoBehaviour
{
    private Hero   hero;
    private TextMeshProUGUI text;
    void Start() {
        hero = GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>();
        text = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if (hero.GetSkillsPoints().ToString() != text.text)
            text.text = hero.GetSkillsPoints().ToString();
    }
}
