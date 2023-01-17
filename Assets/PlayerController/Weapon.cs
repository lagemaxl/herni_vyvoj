using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public event Action<Weapon> AmmoCountChanged;

    [SerializeField]
    protected int pocetNaboju;
    public int PocetNaboju => pocetNaboju;

    protected int aktPocetNaboju;
    public int AktPocetNaboju { 
        get { return aktPocetNaboju; }
        protected set {
            aktPocetNaboju = value;
            AmmoCountChanged?.Invoke(this);
        }
    }

    [SerializeField]
    protected float shootDelay;
    protected float currentShootCooldown;

    [SerializeField]
    protected float reloadTime;
    protected float currentReloadTime;

    protected bool IsReloading => currentReloadTime > 0;

    [Header("Info about bullet")]
    [SerializeField]
    protected GameObject bulletPrefab;
    [SerializeField]
    protected float bulletSpeed;
    [SerializeField]
    protected Transform bulletSpawnPoint;

    [SerializeField]
    protected Color color;

    public Color Color => color;

    // Start is called before the first frame update
    void Start()
    {
        AktPocetNaboju = pocetNaboju;
    }

    protected void Update() {
        UpdateTimers();
        ProcessShootingInput();
        ProcessReloadInput();
    }

    private void OnDisable() {
        if (IsReloading)
            currentReloadTime = reloadTime;
    }

    private void UpdateTimers() {

        currentShootCooldown -= Time.deltaTime;

        if (IsReloading) {
            currentReloadTime -= Time.deltaTime;
            if(currentReloadTime < 0) {
                Reload();
            }
        }
    }
    protected virtual void ProcessShootingInput() {
        if (Input.GetButtonDown("Fire1")) {
            if (AktPocetNaboju > 0 && currentShootCooldown <= 0 && !IsReloading) {
                Shoot();
            }
        }
    }

    private void ProcessReloadInput() {
        if (Input.GetKeyDown(KeyCode.R) && AktPocetNaboju != pocetNaboju && !IsReloading) {
            currentReloadTime = reloadTime;
            Reload();

        }
    }

    protected virtual void Shoot() {
        AktPocetNaboju--;

        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);

        currentShootCooldown = shootDelay;
    }

    protected void Reload() {
        AktPocetNaboju = pocetNaboju;
    }
}