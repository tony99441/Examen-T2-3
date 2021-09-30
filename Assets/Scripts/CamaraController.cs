using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public Transform Background;
    public Transform PlayerTransform; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        var x = PlayerTransform.position.x + 4f; 
        var y = PlayerTransform.position.y + 4f;
        transform.position = new Vector3(x, y, transform.position.z);
        Background.position = new Vector3(transform.position.x, transform.position.y, Background.position.z);



    }
}
