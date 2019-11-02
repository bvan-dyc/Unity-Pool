using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
	public bool isLocked = true;
	public GameObject		skillButton;
	[SerializeField] public GameObject	levelBox;
	[SerializeField] public TextMeshProUGUI		levelText;
	private Hero	hero;
	[SerializeField] public SkillUI	nextSkill;
    public GameObject   skillGO;
    private Skill   skill;
    public void LevelUp()
	{
		Debug.Log("Clicking...");
		Debug.Log(hero.GetSkillsPoints());
		if (!isLocked && skill.level < skill.maxLevel && hero.GetSkillsPoints() > 0) {
			if (skill.upgrade)
				skill = skill.upgrade.GetComponent<Skill>();
			hero.UseTalentPoint();
			levelText.text = skill.level.ToString() + " / " + skill.maxLevel.ToString();
			if (skill.type == Skill.skillType.Passive)
			{
				if (skill.GetComponent<PassiveSkill>().isEnabled == false)
				{
					skill.GetComponent<PassiveSkill>().Activate();
				}
			}
			if (skill.level >= skill.maxLevel && nextSkill != null)
				nextSkill.isLocked = false;
		}
	}

    void Start()
    {
		hero = GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>();
        if (skillGO != null) {
            skill = skillGO.GetComponent<Skill>();
            skillButton.GetComponent<Button>().onClick.AddListener(LevelUp);
        }
		Debug.Log(hero.GetSkillsPoints());

    }
    void Update()
    {
        if (!isLocked && levelBox.activeSelf == false) {
			Debug.Log("Unlock");
			Color32 eraseBackground = new Color32(255, 255, 255, 255);
			skillButton.GetComponent<Image>().color = eraseBackground;
			levelBox.SetActive(true);
			levelText.text = skill.level.ToString() + " / " + skill.maxLevel.ToString();
		}

    }
}
