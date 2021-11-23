using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDDDDDD : MonoBehaviour
{
    private Vector2 lookDirection; //定義看的方向
    private Vector2 rubyPosition; //定義位置
    private Vector2 rubyMove;

    public Animator rubyAnimator; //定義乘載 ruby 的動畫控制器變數箱子
    public Rigidbody2D rb; //定義鋼體(移動用)

    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        rubyAnimator = GetComponent<Animator>(); //遊戲啟動取得 動畫控制器元件
        rb = GetComponent<Rigidbody2D>(); //遊戲啟動器取得 剛體元件
    }

    // Update is called once per frame
    void FixUpdate()
    {
        rubyPosition = transform.position;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        print("Horizontal is: " + horizontal);
        print("Vertical is " + vertical);

        rubyMove = new Vector2(horizontal, vertical);

        //當按鍵輸入不為0時
        if (!Mathf.Approximately(rubyMove.x, 0) || !Mathf.Approximately(rubyMove.y, 0))
        {
            lookDirection = rubyMove;
            lookDirection.Normalize();
        }

        //控制混合樹的動畫:
        rubyAnimator.SetFloat("Look X", lookDirection.x);//給予朝向的數值
        rubyAnimator.SetFloat("Look Y", lookDirection.y);//給予朝向的數值
        rubyAnimator.SetFloat("Speed", rubyMove.magnitude);//把rubyMove的移動向量給予 Speed

        //移動 ruby 位置
        rubyPosition = rubyPosition + speed * rubyMove * Time.deltaTime;
        rb.MovePosition(rubyPosition); //使用鋼體進行移動
    }

}