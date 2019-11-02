using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentManager : MonoBehaviour
{
    public List<GameObject> Talents;
    public List<GameObject> Slots;
    // Start is called before the first frame update
    public GameObject talentSelected;
    public GameObject slotSelected;
    private Hero    hero;
    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            if (talentSelected == null)
                talentSelected = Talents.Find(talent => talent.GetComponent<OverItem>().isInsideBox == true);
            else
                slotSelected = Slots.Find(slot => slot.GetComponent<OverSlot>().isInsideBox == true);
            if (talentSelected != null && slotSelected != null) {
                Debug.Log(slotSelected.GetComponent<OverSlot>().index);
                Debug.Log(talentSelected.GetComponent<SkillUI>());
                Debug.Log(talentSelected.GetComponent<SkillUI>().skillGO);
                hero.activeSkills[slotSelected.GetComponent<OverSlot>().index] =
                    talentSelected.GetComponent<SkillUI>().skillGO;
                slotSelected.GetComponent<OverSlot>().img.sprite = talentSelected.GetComponent<SkillUI>().skillButton.GetComponent<Image>().sprite;
                talentSelected = null;
                slotSelected = null;
            }
        }
    }
}
