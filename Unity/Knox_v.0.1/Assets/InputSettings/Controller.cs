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

    float speed;
    Vector3 dir;

    private void Awake()
    {
        controles = new Controles();

        //inputController.Moverse.Correr.started += ctx => { print("A correr"); };

        //Stick caminar
        controles.Moverse.Mover.performed += ctx => stickL = ctx.ReadValue<Vector2>();
        controles.Moverse.Mover.canceled += _ => stickL = Vector2.zero;

        //Boton correr
        //controles.Moverse.Run.performed += ctx => { running = true; };
        //controles.Moverse.Run.canceled += ctx => { running = false; };

        //Rodar
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
        animator.SetFloat("Walk", stickL.y);
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
