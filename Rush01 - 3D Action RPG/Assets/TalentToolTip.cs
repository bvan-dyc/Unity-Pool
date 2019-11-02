using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TalentToolTip : MonoBehaviour, IPointerEnterHandler
{
    // Start is called before the first frame update
    public GameObject SkillGo;
    public OverItem over;
    public Image img;
    public void OnPointerEnter(PointerEventData eventData)
    {
        SkillGo = gameObject.GetComponent<SkillUI>().skillGO;
        over = gameObject.GetComponent<OverItem>();
        img = gameObject.GetComponent<Image>();
        over.SetName(SkillGo.GetComponent<Skill>().skillName);
        over.SetDetails(SkillGo.GetComponent<Skill>().tooltip);
        over.SetScarcityColor(Color.white);
        over.SetSprite(img.sprite);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
