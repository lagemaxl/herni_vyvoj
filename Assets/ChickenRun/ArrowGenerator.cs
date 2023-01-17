using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    [SerializeField]
    float interval;

    float currentCooldown = 0;

    [SerializeField]
    Vector2 border;

    [SerializeField]
    GameObject arrowPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentCooldown <= 0)
        {
            currentCooldown = interval;
            GenerateArrow();
        } else
        {
            currentCooldown -= Time.deltaTime;
        }
    }

    void GenerateArrow()
    {
        Destroy(Instantiate(arrowPrefab, new Vector3(
            Random.Range(border.x, border.y),
            transform.position.y,
            transform.position.z
            ), Quaternion.identity), 3f);
    }
}
