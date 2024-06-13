using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float jumpSpeed = 20;
    Vector3 clickPosition;
    float groundAngleRimit = 30.0f;
    bool isJump = false;

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
        else if (isJump && Input.GetMouseButtonUp(0))
        {

            Vector3 dragVector = clickPosition - Input.mousePosition;

            //クリックとリリースが同じ座標なら無視
            if (dragVector.sqrMagnitude == 0) { return; }

            rb.velocity = dragVector.normalized * jumpSpeed;//正規化後にジャンプ力をかける(jumpSpeedが加わっていない)
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + "衝突した");
        //ContactPoint[] contacts = collision.contacts;
        ////0番目の衝突情報から、衝突している点の法線を取得。
        //Vector3 otherNormal = contacts[0].normal;
        //float angle=Vector3.Angle(otherNormal,Vector3.up);

        ContactPoint[] contacts = collision.contacts;
        //0番目の衝突情報から、衝突している点の法線を取得。
        Vector3 otherNormal = contacts[0].normal;
        //上方向を示すベクトル。長さは1。
        Vector3 upVector = new Vector3(0, 1, 0);
        //上方向と法線の内積。
        float dotUN = Vector3.Dot(upVector, otherNormal);

        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;

        if (dotDeg <= groundAngleRimit)
        {
            isJump = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {

        Debug.Log("接触中");
        //衝突している点の情報が複数格納されている
        ContactPoint[] contacts = collision.contacts;
        //0番目の衝突情報から、衝突している点の法線を取得。
        Vector3 otherNormal = contacts[0].normal;
        //上方向を示すベクトル。長さは1。
        Vector3 upVector = new Vector3(0, 1, 0);
        //上方向と法線の内積。
        float dotUN = Vector3.Dot(upVector, otherNormal);

        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;

        if (dotDeg <= groundAngleRimit)
        {
            isJump = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("離脱した");
        isJump = false;
    }
}
