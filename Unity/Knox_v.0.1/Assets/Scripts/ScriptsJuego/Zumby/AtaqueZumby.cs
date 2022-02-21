using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueZumby : MonoBehaviour
{

    StatsKnox statsKnox;
    GameObject knox;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        statsKnox = GameObject.Find("Idle").GetComponent<StatsKnox>();
        knox = GameObject.Find("Idle");
        animator = knox.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Jugador")
        {
            statsKnox.lifes--;
            animator.SetTrigger("Dolor");
            print(statsKnox.lifes);
        }
    }
}
