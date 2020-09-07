using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanuki : MonoBehaviour
{
    // 変数の定義と初期化
    public float flap = 800f;
    public float scroll = 5f;
    float direction = 0f;
    float Slide = 30f;  //横移動の力の強さ
    float flaps = 800f;  //ジャンプ時の力の大きさ
    Rigidbody2D rb2d;
    bool jump = false;

    // Use this for initialization
    void Start()
    {
        //コンポーネント読み込み
        rb2d = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
       // キーボード操作
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //左入力時
            rb2d.AddForce(Vector2.right * Slide);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //右入力時
            rb2d.AddForce(Vector2.left * Slide);
        }


        //キャラのy軸のdirection方向にscrollの力をかける
        rb2d.velocity = new Vector2(scroll * direction, rb2d.velocity.y);

        //ジャンプ判定
        if (Input.GetKeyDown("space") && !jump)
        {
            //ジャンプ時
            rb2d.AddForce(Vector2.up * flaps);
            jump = true;
        }

        if (Input.GetKeyDown("c")) 
        {

        }
        
    }
    //設置判定があればジャンプ判定をfalseへ変更
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jump = false;
        }
        jump = false;
    }
}
