using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour
{
        public GameObject Arduino;
    //    CharacterController controller;

    //    public SerialHandler serialHandler;
    //    public Text text;
        public static float xin;
        public static float yin;
    public int Ataristate = 0;
    public Vector3 Resetpoint = new Vector3(0,0,0);

    //Rigidbodyを変数
    Rigidbody rb;
    //移動
    public float speed;

    //ユニティちゃんの位置を入れる
    //    Vector3 playerPos;
    //地面に接触しているか否か
    bool ground;

    // Use this for initialization
    void Start()
    {
        //rigidbodyの値を取得
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float realspeed;
        xin = Arduino.GetComponent<StockData>().Xin;
        yin = Arduino.GetComponent<StockData>().Yin;

        //アナログスティック使用時
 /*               xin = (xin - 513.0f) / 258.5f;
                yin = (yin - 510.0f) / 253.0f;
                if (xin >= -0.05f && xin <= 0.05f)
                {
                    xin = 0.0f;
                }
                if (yin >= -0.05f && yin <= 0.05f)
                {
                    yin = 0.0f;
               }
  */      
        //加速度センサ使用時
        xin = -(xin - 493.5f) / 253.5f;
        yin = -(yin - 527.5f) / 315.5f;
        if (xin >= -0.01f && xin <= 0.01f)
        {
            xin = 0.0f;
        }
        if (yin >= -0.01f && yin <= 0.01f)
        {
            yin = 0.0f;
       }

        if (Arduino.GetComponent<StockData>().Button == 0)
        {
            realspeed = speed * 2;
        }
        else
        {
            realspeed = speed;
        }

        //カメラの向きに合わせた移動
        //        var cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 1, 0)).normalized;
        //       Vector3 direction = cameraForward * Input.GetAxis("Vertical") + Camera.main.transform.right * Input.GetAxis("Horizontal");
        //        Vector3 direction = Vector3.up * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal");
        //アナログスティック
        //        Vector3 direction = Vector3.up * yin + Vector3.right * xin;
        //加速度センサ使用時
        Vector3 direction = Vector3.up * xin + Vector3.right * yin;
        //        Vector3 direction = cameraForward * yin + Camera.main.transform.right * xin;
        Vector3 playerdir = direction;

//        Debug.LogWarning("Handshake" + Input.GetAxis("Vertical"));
//        Quaternion q = Quaternion.LookRotation(playerdir);

        //            transform.Translate(x, 0, z);
        //        controller.Move(direction * speed);

        //現在の位置＋入力した数値の場所に移動する
        if(Arduino.GetComponent<StockData>().RValue >= 400)
        {
            rb.MovePosition(transform.position + direction*realspeed);
        }
 
        //       rb.MovePosition(transform.position + direction);

        //        float x = Input.GetAxis("Horizontal") * speed;
        //        float y = Input.GetAxis("Vertical") * speed;

        //        rb.AddForce(x, y, 0);
        //                 Debug.LogWarning("RValue2 : "+Resetpoint);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            transform.position = (Resetpoint);
 //           rb.MovePosition(0,0,0);
 //               var r = Random.Range(0f, 1f);
 //               var g = Random.Range(0f, 1f);
 //               var b = Random.Range(0f, 1f);
 //               GetComponent<Renderer>().material.color = new Color(r, g, b);
            //move to this object to above.
            //            gameObject.transform.position = Vector3.up * 5;
        }
        if (collision.gameObject.CompareTag("wall2"))
        {
            if(Arduino.GetComponent<StockData>().RValue >= 400)
            transform.position = (Resetpoint);
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall2"))
        {
            transform.position=transform.position;
            if (Arduino.GetComponent<StockData>().RValue >= 400)
                transform.position = (Resetpoint);
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("checkpoint"))
        {
            Resetpoint = new Vector3(42.5f, 18.9f, 0);
        }
        if (collision.gameObject.CompareTag("checkpoint2"))
        {
            Resetpoint = new Vector3(70.5f, 37.1f, 0);
        }
        if (collision.gameObject.CompareTag("checkpoint3"))
        {
            Resetpoint = new Vector3(57, 60, 0);
        }
        /*if (collision.gameObject.CompareTag("wall2"))
        {
            if (Arduino.GetComponent<StockData>().RValue >= 100)
            {
                Debug.LogWarning("RValue1 : ");
                transform.position = (Resetpoint);
            }
        }*/
    }

    //シリアルを受け取った時の処理 新コントローラー対応
    void datainput()
    {
        //       StockData arduino = Arduino.GetComponent<StockData>();
        float RValue = Arduino.GetComponent<StockData>().RValue;
        //               RValue = arduino.getRvalue();
        //       RValue = arduino.getRvalue();
        //        RValue = arduino.Rvalue2;
        //        Debug.LogWarning("RValue : " + RValue);
        //        Debug.LogWarning("Handshake");
        try
        {
            //           Debug.LogWarning("RValue1 : " + RValue);
            //            Debug.LogWarning("RValue : " + RValue);
            //           Debug.LogWarning("RValue2 : "+RValue);
            //           text.text = "ResisterValue : " + (RValue * 4).ToString(); // シリアルの値をテキストに表示

            //           transform.rotation = Quaternion.Euler(0, RValue, 0);
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }
}
