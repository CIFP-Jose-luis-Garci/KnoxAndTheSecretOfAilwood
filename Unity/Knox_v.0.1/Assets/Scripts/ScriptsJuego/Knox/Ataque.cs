using UnityEngine;

public class Ataque : MonoBehaviour
{

    Controles controles;
    GameObject arma;
    Animator animator;
    CharacterController characterController;
    Controller controller;

    bool atacar = false;

    Collider colliderArma;

    private void Awake()
    {
        controles = new Controles();

        // Atacar
        controles.Ataque.Atacar.started += ctx => Atacar();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        arma = GameObject.Find("Arma");
        characterController = GetComponent<CharacterController>();
        colliderArma = GameObject.Find("guja").GetComponent<BoxCollider>();
        controller = GameObject.Find("Idle").GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        SacarArma();
    }

    public void Atacar()
    {
        if (controller.run == false)
        {
            animator.SetTrigger("Atacar");
            atacar = false;
        }
    }

    void SacarArma()
    {
        if (controller.run == false)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("AtaqueLateral") && !atacar)
            {
                arma.SetActive(true);
            }
        }

        else if (controller.run == true || controller.stickL.y != 0f)
        {
            print(controller.stickL.y);
            arma.SetActive(false);
            atacar = false;
        }
    }

    private void OnEnable()
    {
        controles.Enable();
    }

    private void OnDisable()
    {
        controles.Enable();
    }
}
