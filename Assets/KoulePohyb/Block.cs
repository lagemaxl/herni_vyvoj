using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision) {
        var koule = collision.collider.GetComponent<PohybKoule>();

        if (koule) {
            koule.ResetSphere();
        }
    }
}
