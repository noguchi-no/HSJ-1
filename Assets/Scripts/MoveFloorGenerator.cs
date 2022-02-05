using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloorGenerator : MonoBehaviour
{

    public GameObject moveFloor;
    public float span;
    float t;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        if(span < t)
        {
            t = 0.0f;
            GameObject o = Instantiate(moveFloor, transform.position, Quaternion.identity);
            o.SetActive(true);
        }

    }
}
