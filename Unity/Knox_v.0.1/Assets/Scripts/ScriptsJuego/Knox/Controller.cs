using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Controles controles;

    Animator animator;

    //Variable del joystick izquierdo
    public Vector2 stickL;
    bool running;
    public bool run;

    //bool strafing;
    float triggerR;
    float triggerL;

    //Character controller
    CharacterController cc;

    //Rodar
    bool rodar = false;

    //Saltar
    bool saltar;
    float jumpSpeed = 10f;
    float gravity = 9.8f;

    // Velocidades
    public float speed;
    float rotSpeed = 1f;

    Vector3 moveDirection;

    // Vidas
    StatsKnox statsKnox;
    public bool live = true;

    private void Awake()
    {
        controles = new Controles();

        //inputController.Moverse.Correr.started += ctx => { print("A correr"); };

        //Stick caminar
        controles.Moverse.Mover.performed += ctx => stickL = ctx.ReadValue<Vector2>();
        controles.Moverse.Mover.canceled += _ => stickL = Vector2.zero;

        //Boton correr
        controles.Moverse.Run.performed += ctx => { running = true; };
        controles.Moverse.Run.canceled += ctx => { running = false; };

        //Rodar
        controles.Moverse.Rodar.started += ctx => Rodar();
        //controles.Moverse.Rodar.canceled += ctx => rodar = ctx.ReadValueAsButton();

        //Saltar
        controles.Moverse.Saltar.started += ctx => saltar = ctx.ReadValueAsButton();
        controles.Moverse.Saltar.canceled += ctx => saltar = ctx.ReadValueAsButton();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
        statsKnox = GetComponent<StatsKnox>();

    }

    // Update is called once per frame
    void Update()
    {
        if (statsKnox.lifes >= 1 && live)
        {
            Correr();

            Saltar();

            Andar();
        }

        else if (live)
        {
            Muerto();
            live = false;
            Invoke("BoolMuerto", 2.5f);
            print(live);
        }

        //ComprobarRodar();
    }

    /*void ComprobarRodar()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Rodar") && rodar == true)
        {
            print("He terminado de rodar");
            rodar = false;
        }
    }
    */

    void BoolMuerto()
    {
        animator.SetBool("Muerto", false);
    }

    void DejarDeRodar()
    {
        rodar = false;
    }

    void Correr()
    {
        if (running == true && stickL.y > 0f)
        {
            speed = 4f;
            animator.SetBool("Run", true);
            run = true;
        }

        else
        {
            speed = 1.5f;
            animator.SetFloat("Walk", stickL.y);
            animator.SetBool("Run", false);
            run = false;
        }
    }

    void Saltar()
    {

        if (cc.isGrounded && rodar == false)
        {
            moveDirection = new Vector3(0, 0, 0); // Para que vaya recto y no cambie la direccion.
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (saltar == true)
            {
                animator.SetBool("Saltar", true);
                animator.SetBool("isGrounded", false);
                moveDirection.y = jumpSpeed; // Altura de salto.
            }

            else
            {
                animator.SetBool("Saltar", false);
                animator.SetBool("isGrounded", true);
            }
        }
    }

    public void Andar()
    {
        float fwSpeed;
        if (rodar)
        {
            fwSpeed = 1;
        }

        else
        {
            fwSpeed = stickL.y;
        }

        Vector3 dir = transform.TransformDirection(Vector3.forward); // Darle valor a la direccion donde queramos mover el character controller mas adelante.

        cc.SimpleMove(dir * fwSpeed * speed); // Mover el character controller.
        transform.Rotate(0, stickL.x * rotSpeed, 0);

        moveDirection.y -= gravity * Time.deltaTime;

        cc.Move(moveDirection * Time.deltaTime);

        if (stickL.y > 0f)
        {
            animator.SetFloat("Walk", stickL.y);
        }

        else if (stickL.y < 0f)
        {
            animator.SetFloat("Walk", stickL.y);
        }

        else
        {
            animator.SetFloat("Walk", stickL.y);
        }
    }

    void Rodar()
    {
        if (stickL.y > 0 && !rodar)
        {
            animator.SetTrigger("Rodar");
            rodar = true;
            Invoke("DejarDeRodar", 1.4f);
        }

        /*
        else
        {
            animator.ResetTrigger("Rodar");
            animator.SetFloat("Walk", stickL.y);
        }
        */
    }

    void Muerto()
    {
        animator.SetBool("Muerto", true);
    }

    void Escalada()
    {
        print("hOlas");
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Escalada")
        {
            Escalada();
        }
    }

    private void OnEnable()
    {
        controles.Enable();
    }

    private void OnDisable()
    {
        controles.Disable();
    }
}
