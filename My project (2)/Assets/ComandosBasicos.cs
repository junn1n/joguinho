using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComandosBasicos : MonoBehaviour
{
    // Declarando vari�veis:
    public int velocidade; //define a velocidade de movimenta��o
    public int alturaPulo; //define a for�a do pulo
    private Rigidbody2D rbPlayer; //cria vari�vel para recever os componentes de f�sica    
    private Animator anim; //cria a vari�vel de manipula��o para anima��es

    public bool sensor; //sensor para verificar se est� colidindo com o ch�o
    public Transform posicaoSensor; //Posi��o onde o sensor ser� posicionado
    public LayerMask layerChao; //Camada de intera��o*

    private SpriteRenderer sprite;

    public GameObject projetil;

    public Transform localdisparo;



    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //C�digo para movim
        float movimentoX = Input.GetAxisRaw("Horizontal");

        rbPlayer.velocity = new Vector2(movimentoX * velocidade, rbPlayer.velocity.y);

        anim.SetInteger("walk", (int)movimentoX);

        //C�digo para pular
        if (Input.GetButtonDown("Jump") && sensor == true)
        {
            rbPlayer.AddForce(new Vector2(0, alturaPulo));
        }

        anim.SetBool("jump", sensor);

        if (movimentoX > 0)
        {
            sprite.flipX = false; //aperta a seta para a direita o boneco vai para a direita
        }
        else if (movimentoX < 0)
        {
            sprite.flipX = true;//aperta a seta para a esquerda o boneco vai para a esquerda
        }

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("attack");
            GameObject temp = Instantiate(projetil);

            temp.transform.position = localdisparo.transform.position; 


        }
    }

    private void FixedUpdate()
    {

        sensor = Physics2D.OverlapCircle(posicaoSensor.position, 0.1f, layerChao);

    }
}