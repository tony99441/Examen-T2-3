using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenController : MonoBehaviour
{
    public float velocityX = 10f;

    private Rigidbody2D rb; 
    
    
    
    private GameController gameController; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Escalera")
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Enemigo"))
        {
            // Se destruye la bala
            Destroy(this.gameObject);
            // Se destruye el enemigo 
            Destroy(other.gameObject);
            gameController.SumaPuntos(10);
            Debug.Log(gameController.ObtenerPuntos());
        }

        
    }

    
}
