using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDDDDDD : MonoBehaviour
{
    private Vector2 lookDirection; //�w�q�ݪ���V
    private Vector2 rubyPosition; //�w�q��m
    private Vector2 rubyMove;

    public Animator rubyAnimator; //�w�q���� ruby ���ʵe����ܼƽc�l
    public Rigidbody2D rb; //�w�q����(���ʥ�)

    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        rubyAnimator = GetComponent<Animator>(); //�C���Ұʨ��o �ʵe�������
        rb = GetComponent<Rigidbody2D>(); //�C���Ұʾ����o ���餸��
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

        //������J����0��
        if (!Mathf.Approximately(rubyMove.x, 0) || !Mathf.Approximately(rubyMove.y, 0))
        {
            lookDirection = rubyMove;
            lookDirection.Normalize();
        }

        //����V�X�𪺰ʵe:
        rubyAnimator.SetFloat("Look X", lookDirection.x);//�����¦V���ƭ�
        rubyAnimator.SetFloat("Look Y", lookDirection.y);//�����¦V���ƭ�
        rubyAnimator.SetFloat("Speed", rubyMove.magnitude);//��rubyMove�����ʦV�q���� Speed

        //���� ruby ��m
        rubyPosition = rubyPosition + speed * rubyMove * Time.deltaTime;
        rb.MovePosition(rubyPosition); //�ϥο���i�沾��
    }

}