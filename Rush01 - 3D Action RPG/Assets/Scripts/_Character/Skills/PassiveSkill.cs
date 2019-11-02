using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveSkill : Skill
{
    public GameObject user;
	public bool isEnabled = false;

    public virtual void Activate() {}
    public virtual void Desactivate() { }
}
