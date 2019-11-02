using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRandomizer : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons = null;
    [SerializeField] private Enemy unit = null;
    [SerializeField] private Transform weaponHolder = null;

    private void Awake()
    {
        GameObject newWeapon = Instantiate(weapons[Random.Range(0, weapons.Length)], transform);
        newWeapon.layer = LayerMask.NameToLayer("EnemyBullet");
        newWeapon.transform.position = weaponHolder.position;
        unit.weapon = newWeapon.GetComponent<Weapon>();
        if (unit.weapon.getType() == Weapon.WeaponType.ranged)
            ((RangedWeapon)unit.weapon).infiniteAmmo = true;
    }
}
