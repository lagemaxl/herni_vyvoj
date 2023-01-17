using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float teleportSpeed = 30;

    private void OnCollisionEnter(Collision collision) {
        var koule = collision.collider.GetComponent<PohybKoule>();

        if(koule) {
            koule.GetComponent<Rigidbody>().AddForce(Vector3.up* teleportSpeed, ForceMode.Impulse);
        }
    }
}
