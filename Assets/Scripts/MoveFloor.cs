using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    public float speed;

    float t;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveAccount = speed * Time.deltaTime;

        t += moveAccount;
        transform.position += new Vector3(0, moveAccount, 0);

        if (transform.position.y > 5.25f) Destroy(this.gameObject);
    }
}
