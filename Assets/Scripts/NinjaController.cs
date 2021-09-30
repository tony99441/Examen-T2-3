using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    public float velocityX;
    public float JumpForce; 
    
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;

    
    private const int Idle = 0;
    private const int Correr = 1;
    private const int Saltar = 2;
    private const int SubirEscaleras = 3;
    private const int Slide = 4;
    private const int Volar = 5;
    private const int Morir = 6;
    private const int LanzaShurikens = 7;
    private bool puedeVolar = false;

    public GameObject shurikenDerecha;
    public GameObject shurikenIzquierda; 
    
    private int estaMuerto = 0;
    private int vidasRestantes = 3;
    private bool puedeSubirEscalera = false;
    public float speed = 5;
    public int contador = 0; 
    
  
    public float tiempoMuere = 0f;
    public int tiempo = 0;
    
    private GameController gameController; 
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        gameController = FindObjectOfType<GameController>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (estaMuerto == 0)
        {
            rb.gravityScale = 10;
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetInteger("Estado",0);

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector2(-velocityX, rb.velocity.y);
                sr.flipX = true;
                changeAnimation(Correr);
            } 
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(velocityX, rb.velocity.y);
                sr.flipX = false;
                changeAnimation(Correr);
            } 

            if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.LeftArrow))
            {
                sr.flipX = true;
                rb.velocity = new Vector2(-velocityX, 0); 
                changeAnimation(Slide);
            }
            if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.RightArrow))
            {
                sr.flipX = false;
                rb.velocity = new Vector2(velocityX, 0); 
                changeAnimation(Slide);
            }
            
            
            if (  Input.GetKeyUp(KeyCode.Space))
            {
                rb.AddForce(Vector2.up*JumpForce, ForceMode2D.Impulse);
                changeAnimation(Saltar);
            }
            

            if (puedeSubirEscalera && Input.GetKey(KeyCode.UpArrow))
            {
                changeAnimation(SubirEscaleras);
                rb.gravityScale = 0; 
                rb.velocity = Vector2.up * (speed-2) ;
            }
            if (puedeSubirEscalera && Input.GetKey(KeyCode.DownArrow))
            {
                changeAnimation(SubirEscaleras);
                rb.gravityScale = 10; 
                rb.velocity = Vector2.down * (speed-2) ;
                
            }
            
            

            
            if (Input.GetKey(KeyCode.X) & puedeVolar == false)
            {
                changeAnimation(Volar);
                rb.gravityScale = 0;
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    rb.velocity = new Vector2(rb.velocity.x, 5); 
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    rb.velocity = new Vector2(rb.velocity.x, -5); 
                }

            }

            if (Input.GetKeyDown(KeyCode.X) && puedeVolar == false)
            {
                rb.gravityScale = 10;
                changeAnimation(Idle);
                puedeVolar = false;
            }
            
            if (Input.GetKeyUp(KeyCode.C))
            {
                changeAnimation(LanzaShurikens);
                var shuriken = sr.flipX ? shurikenIzquierda : shurikenDerecha;
                var position = new Vector2(transform.position.x, transform.position.y);
                var rotation = shurikenDerecha.transform.rotation;
                Instantiate(shuriken,position,rotation);
            }

            



        }
        
        
        if (estaMuerto == 1)
        {
            changeAnimation(Morir);
        }

      



    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Escalera")
        {
            puedeSubirEscalera = true;
            rb.gravityScale = 0;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            gameController.RestaVidas(1);
            Debug.Log(" Si choca con el enemigo");
            vidasRestantes -= 1; 

        }

        if (vidasRestantes <=0)
        {
            estaMuerto = 1;
            gameController.NoVidas();
            
        }


        if (collision.gameObject.CompareTag("Piso2"))
        {
            Debug.Log("Si colisiona");
            contador = 1; 
        }

        if (collision.gameObject.CompareTag("Suelo") && contador ==1)
        {
            estaMuerto = 1;
        }





    }
    
    
    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
    
    

}
