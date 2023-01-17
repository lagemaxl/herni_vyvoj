using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PohybKoule : MonoBehaviour
{
    bool move = false;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ResetSphere() {
        transform.position = Vector3.zero;
        rb.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButton(1))
            return;

        var pos = Input.mousePosition;
        var dir = new Vector3(pos.x - Screen.width / 2, 0, pos.y - Screen.height / 2);
        rb.AddForce(dir* Time.deltaTime);

        if(Input.GetMouseButtonDown(0)) {
            ResetSphere();
        }
    }
}
