using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesAleatorios2Controller : MonoBehaviour
{
    public GameObject ZombieM2;
    public float tiempoParaAparecer = 17;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CrearEnemigo", 9, tiempoParaAparecer);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CrearEnemigo()
    {
        Instantiate(ZombieM2, transform.position, Quaternion.identity);
    }
}
