using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesAleatorios3 : MonoBehaviour
{
    public GameObject ZombieF;
    
    public float tiempoParaAparecerF = 27;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CrearEnemigo", 13, tiempoParaAparecerF);
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(ZombieF, -transform.position, Quaternion.identity);
    }
}
