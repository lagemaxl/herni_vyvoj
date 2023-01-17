using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smg : Weapon
{
    protected override void ProcessShootingInput() {
        if (Input.GetButton("Fire1")) {
            if (aktPocetNaboju > 0 && currentShootCooldown <= 0 && !IsReloading) {
                Shoot();
            }
        }
    }
}
