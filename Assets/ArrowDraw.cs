using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ArrowDraw : MonoBehaviour
{
    [SerializeField] Image ArrowImage;
    Vector3 clickPosition;

    // Start is called before the first frame update
    void Start()
    {
        ArrowImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
            ArrowImage.rectTransform.sizeDelta = Vector2.zero;
            ArrowImage.gameObject.SetActive(true);
        }
        else if (Input.GetMouseButton(0))
        {
          
            Vector3 dragVector = clickPosition - Input.mousePosition;
            Debug.Log(dragVector);
            //�x�N�g���̒������Z�o
            float size = dragVector.magnitude;
            //�x�N�g������p�x�i�ʓx�@�j���Z�o
            float angleRad = Mathf.Atan2(dragVector.y, dragVector.x);
            //���̉摜���N���b�N�����ꏊ�ɉ摜���ړ�
            ArrowImage.rectTransform.position = clickPosition;
            //���̉摜���x�N�g������Z�o�����p�x��x���@�ɕϊ�����Z����]
            ArrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angleRad * Mathf.Rad2Deg);
            //���̉摜�̑傫�����h���b�O���������ɍ��킹��
            ArrowImage.rectTransform.sizeDelta = new Vector2(size, size);
        }
        else if (!Input.GetMouseButton(0)) { ArrowImage.gameObject.SetActive(false); }
    }
}
