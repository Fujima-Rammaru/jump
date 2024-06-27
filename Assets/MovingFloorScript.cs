using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloorScript : MonoBehaviour
{
    public int speed;
    private Vector3 startPos;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(transform.position);
      //  float posX = startPos.x + Mathf.PingPong(Time.time * speed, 12);
        rb.MovePosition(new Vector3(startPos.x, Mathf.PingPong(Time.time, 5), startPos.z));
    }
}
