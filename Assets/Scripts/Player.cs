using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float angle;
    public float power;

    public float power2nd;
    public float power3rd;

    bool isShot = false;
    bool end1st = false;
    bool end2nd = false;

    bool isEnd = false;

    float angle2nd;
    float angle3rd;

    Vector2 startPos;
    Vector2 endPos;
    Vector2 vec;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Shot();

        if(Input.GetKeyDown("r")) SceneManager.LoadScene("Game");
    }

    void Shot()
    {

        if (!isShot)
        {

            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("押された");
                startPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            }
            else if(Input.GetMouseButton(0))
            {
                //Debug.Log("押されている");
                
                Vector2 tempVec = new Vector2(startPos.x - Input.mousePosition.x, startPos.y - Input.mousePosition.y);
                
                power = tempVec.magnitude;

                angle = CalculateAngle(tempVec);
               
            }
            else if (Input.GetMouseButtonUp(0))
            {

                isShot = true;

                //Debug.Log("リリース");
                endPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);


                vec = new Vector2(startPos.x - endPos.x, startPos.y - endPos.y);

                //vec = vec / vec.magnitude;

                //Vector2 force = new Vector2(xPower, yPower);

                rb.AddForce(vec);

            }
             
        }

    }

    float CalculateAngle(Vector2 _vec)
    {
        _vec = _vec / _vec.magnitude;

        float tempAng = Mathf.Atan2(_vec.y, _vec.x) * Mathf.Rad2Deg;

        return Mathf.Repeat(tempAng, 360);

    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (isShot)
        {
            Debug.Log(coll.gameObject);

            if (!end1st)
            {
                end1st = true;
                Debug.Log("1回目の着地");

                angle2nd = angle - Mathf.Repeat(Mathf.Atan2(coll.contacts[0].normal.x, coll.contacts[0].normal.y) * Mathf.Rad2Deg, 360);

                Debug.Log(angle);
                Debug.Log(Mathf.Repeat(Mathf.Atan2(coll.contacts[0].normal.x, coll.contacts[0].normal.y) * Mathf.Rad2Deg, 360));

                Vector2 nextVector = new Vector2(Mathf.Cos(angle2nd * Mathf.Deg2Rad), Mathf.Sin(angle2nd * Mathf.Deg2Rad)) * power * power2nd;

                //rb.AddForce(nextVector);
                //if(coll.gameObject.tag == "Wall")
                //{
                //    vec = new Vector2(-vec.x, vec.y);
                //    rb.AddForce(vec * 1.5f);
                //} 
                //else
                //{
                //    rb.AddForce(vec * 1.5f);
                //}

            } 
            else if(!end2nd)
            {
                end2nd = true;
                Debug.Log("2回目の着地");

                angle3rd = angle2nd - Mathf.Repeat(Mathf.Atan2(coll.contacts[0].normal.x, coll.contacts[0].normal.y) * Mathf.Rad2Deg, 360);

                Vector2 nextVector = new Vector2(Mathf.Cos(angle3rd * Mathf.Deg2Rad), Mathf.Sin(angle3rd * Mathf.Deg2Rad)) * power * power3rd;

                //rb.AddForce(nextVector);
                
                //if (coll.gameObject.tag == "Wall")
                //{
                //    vec = new Vector2(-vec.x, vec.y);
                //    rb.AddForce(vec * 2.0f);
                //}
                //else
                //{
                //    rb.AddForce(vec * 2.0f);
                //}
            }
        }
    }
}


