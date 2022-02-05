using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvGravityWall : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        player.GetComponent<Rigidbody2D>().gravityScale = -1.0f;
    }
}
