using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponDisplay : MonoBehaviour
{
    [Header("WeaponInfo objekty")]

    [SerializeField]
    Transform weaponInfo;

    [SerializeField]
    Image weaponImage;

    [SerializeField]
    TMP_Text weaponName;


    [Header("AmmoInfo objekty")]

    [SerializeField]
    TMP_Text ammoCount;

    [SerializeField]
    Image reloadProgress;

    [SerializeField]
    WeaponSwap weaponSwap;

    // Start is called before the first frame update
    void Awake()
    {
        weaponSwap.WeaponChanged += OnWeaponChanged;
        weaponSwap.Weapons.ForEach(w => w.AmmoCountChanged += OnAmmoCountChanged);

    }

    private void OnAmmoCountChanged(Weapon weapon) {
        ChangeAmmo(weapon.AktPocetNaboju, weapon.PocetNaboju);
    }

    private void OnWeaponChanged(Weapon weapon) {
        weaponName.text = weapon.name;
        weaponImage.color = weapon.Color;

        ChangeAmmo(weapon.AktPocetNaboju, weapon.PocetNaboju);
    }

    private void ChangeAmmo(int current, int max) {
        ammoCount.text = $"{current}/{max}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
