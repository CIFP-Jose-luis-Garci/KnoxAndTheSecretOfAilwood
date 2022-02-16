using UnityEngine;

public class Ataque : MonoBehaviour
{

    Controles controles;
    GameObject arma;
    Animator animator;
    CharacterController characterController;

    bool atacar = false;



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
    }

    // Update is called once per frame
    void Update()
    {
        SacarArma();
    }

    public void Atacar()
    {
         animator.SetTrigger("Atacar");
         atacar = false; 
    }

    void SacarArma()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("AtaqueLateral") && !atacar)
        {
            arma.SetActive(true);
            print("Pongo");
        }

        else
        {
            arma.SetActive(false);
            atacar = false;
            print("Quito");
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
