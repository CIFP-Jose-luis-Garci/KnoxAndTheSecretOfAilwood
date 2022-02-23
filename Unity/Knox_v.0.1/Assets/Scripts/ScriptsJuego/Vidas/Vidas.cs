using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidas : MonoBehaviour
{

    StatsKnox stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.Find("Idle").GetComponent<StatsKnox>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Jugador" && stats.lifes < 6 && stats.lifes >1)
        {
            stats.lifes += 1;
            Destroy(gameObject);
        }
    }
}
