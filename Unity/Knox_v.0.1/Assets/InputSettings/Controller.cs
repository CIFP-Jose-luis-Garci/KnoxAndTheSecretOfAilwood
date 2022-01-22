using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Controles controles;

    Animator animator;

    //Variable del joystick izquierdo
    Vector2 stickL;
    bool running;
    //bool strafing;
    float triggerR;
    float triggerL;
    //Character controller
    CharacterController cc;

    //Rodar
    bool rodar;

    //Saltar
    bool saltar;
    float jumpSpeed = 5f;
    float gravity = 9.8f;

    float impulse;
    float speed;
    Vector3 dir;
    Vector3 moveDirection;

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
        controles.Moverse.Rodar.started += ctx => rodar = ctx.ReadValueAsButton();
        controles.Moverse.Rodar.canceled += ctx => rodar = ctx.ReadValueAsButton();

        //Saltar
        controles.Moverse.Saltar.started += ctx => saltar = ctx.ReadValueAsButton();
        controles.Moverse.Saltar.canceled += ctx => saltar = ctx.ReadValueAsButton();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(running == true && stickL.y > 0f)
        {
            speed = 5f;
            animator.SetBool("Run", true);
        }
        else
        {
            speed = 2f;
            animator.SetFloat("Walk", stickL.y);
            animator.SetBool("Run", false);
        }

        if(rodar == true && stickL.y > 0)
        {
            
            animator.SetTrigger("Rodar");
            
        }
        else
        {

            animator.ResetTrigger("Rodar");
            animator.SetFloat("Walk", stickL.y);
        }

        if(cc.isGrounded)
        {
            
            moveDirection = new Vector3(0, 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if(saltar == true)
            {
                animator.SetTrigger("Saltar");
                moveDirection.y = jumpSpeed;
            }
            
        }
        else
        {
            animator.ResetTrigger("Saltar");
            animator.SetFloat("Walk", stickL.y);
        }

        moveDirection.y -= gravity * Time.deltaTime;
        cc.Move(moveDirection * Time.deltaTime);

        dir = transform.TransformDirection(Vector3.forward);
        cc.SimpleMove(speed * stickL.y * dir);


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
