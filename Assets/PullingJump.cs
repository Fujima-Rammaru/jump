using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float jumpSpeed = 20;
    Vector3 clickPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;

        }
        if (Input.GetMouseButtonUp(0))
        {

            Vector3 dragVector = clickPosition - Input.mousePosition;

            //クリックとリリースが同じ座標なら無視
            if (dragVector.sqrMagnitude == 0) { return; }

            rb.velocity = dragVector.normalized * jumpSpeed;
        }
    }
}
