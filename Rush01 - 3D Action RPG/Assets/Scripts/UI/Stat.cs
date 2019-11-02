using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stat : MonoBehaviour
{
    public TextMeshProUGUI  text;
    public TextMeshProUGUI     textValue;
    private Hero      hero;
    public Button   button;
    void SetValue() {
        if (text.text == "Strength")
            textValue.text = hero.data.strength.ToString();
        else if (text.text == "Agility")
            textValue.text = hero.data.agility.ToString();
        else if (text.text == "Constitution")
            textValue.text = hero.data.constitution.ToString();
        else if (text.text == "Armor")
            textValue.text = hero.data.armor.ToString();
        else if (text.text == "Level")
            textValue.text = hero.data.level.ToString();
        else if (text.text == "XP")
            textValue.text = hero.data.xp.ToString();
        else if (text.text == "XP to next level")
            textValue.text = hero.data.xpToNextLevel.ToString();
        else if (text.text == "Credits")
            textValue.text = hero.data.credits.ToString();
        else if (text.text == "Intelligence")
            textValue.text = hero.data.intelligence.ToString();
        else if (text.text == "Maximum HP")
            textValue.text = hero.data.maxHP.ToString();
        else if (text.text == "Minimum damage")
            textValue.text = hero.data.minDamage.ToString();
        else if (text.text == "Maximum damage")
            textValue.text = hero.data.maxDamage.ToString();
        // else if (text.text == "Agility")
        //     textValue.text = hero.data.agility.ToString();
    }

    void AddValue() {
        if (hero.GetAttributePoints() > 0) {
            // hero.data.GetType().GetField("strength").SetValue(heroData, );
            hero.UseAttributePoint();
            if (text.text == "Strength")
                hero.data.strength += 1;
            else if (text.text == "Agility")
                hero.data.agility += 1;
            else if (text.text == "Constitution")
                hero.data.constitution += 1;
            else if (text.text == "Armor")
                hero.data.armor += 1;
            else if (text.text == "Level")
                hero.data.level += 1;
            // else if (text.text == "XP")
            //     hero.data.xp += 1;
            // else if (text.text == "XP to next level")
            //     hero.data.xpToNextLevel += 1;
            else if (text.text == "Credits")
                hero.data.credits += 1;
            else if (text.text == "Intelligence")
                hero.data.intelligence += 1;
            SetValue();
        }
    }

    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>();
        SetValue();
        button.onClick.AddListener(AddValue);
    }

    void Update()
    {

    }
}
