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
            //ベクトルの長さを算出
            float size = dragVector.magnitude;
            //ベクトルから角度（弧度法）を算出
            float angleRad = Mathf.Atan2(dragVector.y, dragVector.x);
            //矢印の画像をクリックした場所に画像を移動
            ArrowImage.rectTransform.position = clickPosition;
            //矢印の画像をベクトルから算出した角度を度数法に変換してZ軸回転
            ArrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angleRad * Mathf.Rad2Deg);
            //矢印の画像の大きさをドラッグした距離に合わせる
            ArrowImage.rectTransform.sizeDelta = new Vector2(size, size);
        }
        else if (!Input.GetMouseButton(0)) { ArrowImage.gameObject.SetActive(false); }
    }
}
