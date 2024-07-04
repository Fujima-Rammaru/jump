using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloorScript : MonoBehaviour
{
    public int speed;
    private Vector3 startPos;
    private Vector3 startPos2;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        if (rb.tag == "floor1")
        {
            transform.position = new Vector3(0, 0, 0);
            startPos = transform.position;
        }

        if (rb.tag == "floor2")
        {
            startPos2 = new Vector3(5.0f,4.0f,0.0f);
        }


    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(transform.position);
        //  float posX = startPos.x + Mathf.PingPong(Time.time * speed, 12);
        if (rb.tag == "floor1")
        {
            rb.MovePosition(new Vector3(startPos.x, Mathf.PingPong(Time.time, 3)-0.5f, startPos.z));
        }

        if (rb.tag == "floor2")
        {
            rb.MovePosition(new Vector3(Mathf.PingPong(Time.time, 4)+5, startPos2.y, startPos2.z));
        }

    }
}
