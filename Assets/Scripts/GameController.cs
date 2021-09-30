using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int Puntos = 0;
    public Text PuntosText;

    private int Vidas = 3;
    public Text VidasText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        PuntosText.text = "Puntos en total: "+Puntos;

        VidasText.text = "Vidas Restantes: " +Vidas; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int ObtenerPuntos()
    {
        return this.Puntos;
       
    }
    
    public void SumaPuntos(int puntos)
    {
        this.Puntos += puntos;
        PuntosText.text = "Puntos: "+Puntos;
    }
    

    public void RestaVidas(int vidas)
    {
        this.Vidas -= vidas;
        VidasText.text = "Vidas Restantes: " + Vidas;
        

    }



    public void NoVidas()
    {
        VidasText.text = "No tienes vidas :(";
    }




}
