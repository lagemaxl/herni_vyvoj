using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public event Action<PlayerDamage> LivesChanged;

    private int lives = 3;
    private bool isDead = false;

    private bool isImmortal = false;
    [SerializeField]
    private float hitImmortality = 1.5f;

    [SerializeField]
    private MeshRenderer playerGraphics;


    public int Lives
    {
        get { return lives; }
        set { 
            lives = value;
            CheckForDead();
            LivesChanged?.Invoke(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDead || isImmortal)
            return;
        Lives--;
        collision.collider.enabled = false;
        isImmortal = true;

        playerGraphics.material.color = new Color(185/255f, 143/255f, 0, 0.25f);
        Invoke("BecomeMortal", hitImmortality);

        Debug.Log("Au! " + collision.collider.name);
    }

    private void BecomeMortal() {
        isImmortal = false;
        playerGraphics.material.color = new Color(185 / 255f, 143 / 255f, 0, 1f);
    }

    private void CheckForDead()
    {
        if(lives == 0)
        {
            isDead = true;
            Time.timeScale = 0;
        }
    }

}
