using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    private float jumpSpeed = 20.0f;
    Vector3 clickPosition;
    float groundAngleRimit = 30.0f;
    bool isJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        jumpSpeed = 20.0f;
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

            //�N���b�N�ƃ����[�X���������W�Ȃ疳��
            if (dragVector.sqrMagnitude == 0) { return; }
            jumpSpeed = dragVector.magnitude * 0.1f;
            if (jumpSpeed > 20.0f)
            {
                jumpSpeed = 20.0f;
            }
            rb.velocity = dragVector.normalized * jumpSpeed;//���K����ɃW�����v�͂�������(jumpSpeed��������Ă��Ȃ�)
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + "�Փ˂���");

        ContactPoint[] contacts = collision.contacts;
        //0�Ԗڂ̏Փˏ�񂩂�A�Փ˂��Ă���_�̖@�����擾�B
        Vector3 otherNormal = contacts[0].normal;
        //������������x�N�g���B������1�B
        Vector3 upVector = new Vector3(0, 1, 0);
        //������Ɩ@���̓��ρB
        float dotUN = Vector3.Dot(upVector, otherNormal);

        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;

        if (dotDeg <= groundAngleRimit)
        {
            isJump = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {

        Debug.Log("�ڐG��");
        //�Փ˂��Ă���_�̏�񂪕����i�[����Ă���
        ContactPoint[] contacts = collision.contacts;
        //0�Ԗڂ̏Փˏ�񂩂�A�Փ˂��Ă���_�̖@�����擾�B
        Vector3 otherNormal = contacts[0].normal;
        //������������x�N�g���B������1�B
        Vector3 upVector = new Vector3(0, 1, 0);
        //������Ɩ@���̓��ρB
        float dotUN = Vector3.Dot(upVector, otherNormal);

        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;

        if (dotDeg <= groundAngleRimit)
        {
            isJump = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("���E����");
        isJump = false;
    }

}
