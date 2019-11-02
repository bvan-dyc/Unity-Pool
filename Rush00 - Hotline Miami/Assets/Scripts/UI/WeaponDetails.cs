using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDetails : MonoBehaviour
{
    private Player  player;
    private Weapon  weaponSaved;
    private int currentMunition = 0;
    private Text  weaponName;
    private Text  weaponMunition;

    void EditMunitionNumber(int munition) {
        currentMunition = munition;
        if (weaponSaved.ammunition == int.MaxValue)
            weaponMunition.text = "Inf";
        else
            weaponMunition.text = munition.ToString();
    }
    void EditEquipedWeapon(Weapon newWeapon) {
        weaponSaved = newWeapon;
        if (newWeapon) {
            weaponName.text = weaponSaved.name;
            EditMunitionNumber(weaponSaved.ammunition);
        }
        else {
            weaponName.text = "No weapon";
            weaponMunition.text = "-";
        }
    }
    void Start()
    {
		GameObject[] weaponDetailsGO = GameObject.FindGameObjectsWithTag("WeaponDetails");
        foreach(GameObject details in weaponDetailsGO) {
            if (details.name == "Name")
                weaponName = details.GetComponent<Text>();
            else if (details.name == "Munition")
                weaponMunition = details.GetComponent<Text>();
        }
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        weaponSaved = player.getWeapon();
        EditEquipedWeapon(weaponSaved);
    }

    void Update()
    {
        Weapon currentWeapon = player.getWeapon();
        if (!currentWeapon && weaponName.text != "No weapon")
            EditEquipedWeapon(null);
        else if (currentWeapon != weaponSaved)
            EditEquipedWeapon(currentWeapon);
        else if (currentWeapon && currentMunition != currentWeapon.ammunition)
            EditMunitionNumber(currentWeapon.ammunition);
    }
}
