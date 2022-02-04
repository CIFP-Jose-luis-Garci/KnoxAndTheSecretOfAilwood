using UnityEngine;

public class Ataque : MonoBehaviour
{

    Controles controles;
    GameObject player;
    GameObject arma;

    Animator animator;

    bool atacar = false;
    bool ataque;


    private void Awake()
    {
        controles = new Controles();

        // Atacar
        controles.Ataque.Atacar.started += ctx => Atacar();
        //controles.Ataque.Atacar.canceled  += ctx => {ata;

    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        arma = GameObject.Find("Arma");
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("AtaqueLateral") && !atacar)
        {
            arma.SetActive(true);
        }

        else
        {
            arma.SetActive(false);
            atacar = false;
        }
    }

    public void Atacar()
    {
         animator.SetTrigger("Atacar");
         atacar = true;
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
