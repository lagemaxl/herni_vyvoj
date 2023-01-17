using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    public event Action<Weapon> WeaponChanged;

    List<Weapon> weapons;

    public List<Weapon> Weapons { 
        get { 
            if(weapons == null) {
                weapons = GetComponentsInChildren<Weapon>(true).ToList();
            }    
            return weapons; 
        }   
    }

    // Start is called before the first frame update
    void Start()
    {
        
        ActivateWeapon(0);
    }

    private void ActivateWeapon(int index) {
        // deaktivace všech zbraní
        weapons.ForEach(weapon => { weapon.gameObject.SetActive(false); });

        // aktivace zbranì s indexem z parametru
        weapons[index].gameObject.SetActive(true);

        WeaponChanged?.Invoke(weapons[index]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { ActivateWeapon(0); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { ActivateWeapon(1); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { ActivateWeapon(2); }
    }
}
