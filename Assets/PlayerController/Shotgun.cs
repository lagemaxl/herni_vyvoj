using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField]
    private float spread;
    [SerializeField]
    private int bulletCount;

    protected override void Shoot() {
        AktPocetNaboju--;
        currentShootCooldown = shootDelay;

        for(int i = 0; i < bulletCount; i++) {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(GetDirection() * bulletSpeed);
        }
    }

    private Vector3 GetDirection() {
        Vector3 dir = transform.forward;

        dir.x += Random.Range(-spread, spread);
        dir.y += Random.Range(-spread, spread);
        dir.z += Random.Range(-spread, spread);

        return dir;
    }
}
