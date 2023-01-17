using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField]
    PlayerDamage playerDamage;

    [SerializeField]
    TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        playerDamage.LivesChanged += OnLivesChanged;
    }

    private void OnLivesChanged(PlayerDamage dmg)
    {
        text.text = dmg.Lives.ToString();
    }
}
