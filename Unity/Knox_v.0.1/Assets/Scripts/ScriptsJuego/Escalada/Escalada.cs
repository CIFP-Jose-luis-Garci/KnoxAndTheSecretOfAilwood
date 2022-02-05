using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalada : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Idle");
    }

    // Update is called once per frame
    void Update()
    {

    }


    void Escalar()
    {

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Jugador")
        {
            print("Hola");
        }
    }
}
