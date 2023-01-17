using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField]
    private Transform followObject;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - followObject.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = followObject.position + offset;
    }
}
