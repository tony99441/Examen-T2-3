using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesAleatoriosController : MonoBehaviour
{
    public GameObject ZombieM;
   public GameObject ZombieF;
    public float tiempoParaAparecer = 9;
 public float tiempoParaAparecerF = 18;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CrearEnemigo", 8, tiempoParaAparecer);
         InvokeRepeating("CrearEnemigo", 13, tiempoParaAparecerF);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CrearEnemigo()
    {
        Instantiate(ZombieM, transform.position, Quaternion.identity);
        Instantiate(ZombieF, transform.position, Quaternion.identity);
    }
    
}
