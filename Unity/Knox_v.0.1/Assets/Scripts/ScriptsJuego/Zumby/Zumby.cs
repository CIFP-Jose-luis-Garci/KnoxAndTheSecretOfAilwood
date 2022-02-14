using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zumby : MonoBehaviour
{
    //Variables para el FSM
    Vector3 goal; //Hacia donde se dirigirá

    //Necesito saber en todo momento mi distancia al objetivo
    float distance;

    //Booleana que me permite saber si ha detectado al jugador
    bool detected;
    bool pillado = false;

    //Componente Nav Mesh Agent
    NavMeshAgent agent;

    //Destinos posibles (el empty de la ronda y el jugador)
    [SerializeField] Transform emptyGoal, survivor;

    //Componente Animator
    Animator animator;

    //Sonidos
    //[SerializeField] AudioClip groar1;
    //AudioSource audioSource;

    //Variables para detectar al jugador
    float visionRange = 10f; //10 metros de visión
    float visionConeAngle = 60f; //60º de angulo de visión

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        //audioSource.GetComponent<AudioSource>();

        //Iniciamos la corrutina que hace que se mueva aleatoriamiente
        StartCoroutine("Ronda");
    }

    // Update is called once per frame
    void Update()
    {
        //Función que permite detectar al jugador
        Detectar();

        animator.SetFloat("Move", agent.speed);

        //Si me han detectado, cambio la animación
        if (detected)
        {
            goal = survivor.position;
            //audioSource.Play();
        }

        else
        {
            goal = emptyGoal.position;
        }

        distance = Vector3.Distance(transform.position, goal);
        //print(distance);

        //Si la distancia al objetivo es menor 
        if (distance > 1f)
        {
            agent.speed = 2f;
        }

        else
        {
            agent.speed = 0f;
        }

        agent.SetDestination(goal);
    }

    IEnumerator Ronda()
    {
        while (!detected)
        {
            //Obtengo valores aleatorios para un nuevo Vector3
            float RandomX = Random.Range(-5f, 5f);
            float RandomZ = Random.Range(-5f, 5f);
            //Creo un Vector3 relativo a mi posición
            Vector3 randomPos = new Vector3(RandomX, 0, RandomZ);
            Vector3 destPos = transform.position + randomPos;

            yield return new WaitForSeconds(Random.Range(3f, 7f));

            //Muevo el objetivo a la posición aleatoria
            emptyGoal.transform.position = destPos;
        }
    }

    void Detectar()
    {
        //Creamos un Vector3 con la posiciÃ³n del jugador, y otro entre nosotros y Ã©l
        Vector3 playerPosition = survivor.position;
        Vector3 vectorToPlayer = playerPosition - transform.position;

        //Distancia hasta el jugador y angulo que forma nuestra vision frontal con el
        //Si es una IA, podemmos con navMeshAgent, podemos usar remainingDistance
        float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
        float angleToPlayer = Vector3.Angle(transform.forward, vectorToPlayer);

        //Si esta en mi rango y en mi angulo de vision
        if (distanceToPlayer <= visionRange && angleToPlayer <= visionConeAngle)
        {
            if (!pillado)
            {
                print("Me han pillado");
                detected = true;
                pillado = true;
                animator.SetBool("Ataque", true);
                StopCoroutine("Ronda");
            }
        }

        else
        {
            if (pillado)
            {
                detected = false;
                pillado = false;
                animator.SetBool("Ataque", false);
                StartCoroutine("Ronda");
            }
        }
        //print(distanceToPlayer + " - " + detected);
    }
}
