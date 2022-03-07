//using java.applet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    Controles controles;
    BotonesPausa bP;
    Animator animator;

    //Variable del joystick izquierdo
    public Vector2 stickL;
    bool running;
    public bool run;

    AudioSource audioSource;
    [SerializeField] AudioClip correrAudio;


    //Boolena que me dice que estoy saltando
    bool saltando = false;

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
    float gravity = -9.8f;

    //BotonStart
    public bool startBtt;

    // Velocidades
    public float speed;
    float rotSpeed = 1f;

    Vector3 moveDirection;

    // Saltar
    Vector3 velocity;
    bool isGrounded;
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask floorMask;

    // Vidas
    StatsKnox statsKnox;
    public bool live = true;

    // Camera
    public Transform cam;
    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

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
        /*
        controles.Moverse.Saltar.started += ctx => saltar = ctx.ReadValueAsButton();
        controles.Moverse.Saltar.canceled += ctx => saltar = ctx.ReadValueAsButton();

        */
        controles.Moverse.Saltar.started += ctx =>  Saltar();
       // controles.Moverse.Saltar.canceled += ctx => { saltar = false; };

        //Boton Pause
        bP = GameObject.Find("UI").GetComponent<BotonesPausa>();
         controles.UI.Start.performed += _ => bP.PauseScreen();

        
    }
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
        statsKnox = GetComponent<StatsKnox>();
        audioSource = GetComponent<AudioSource>();
       // audioSource.volume = 1;
    }

    // Update is called once per frame
    void Update()
    {
        print(groundCheck.transform.position.y);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, floorMask);
        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);

        if(saltando && cc.isGrounded)
        {
            animator.SetBool("Saltar", false);
            animator.SetBool("isGrounded", true);
            saltando = false;
        }

        if (statsKnox.lifes >= 1 && live && bP.gamePaused == false)
        {
            Correr();

            Andar();
        }

        else if (live && bP.gamePaused == false)
        {
            Muerto();
            
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
        
        if (running == true)
        {
            speed = 5f;
            animator.SetBool("Run", true);
            run = true;
            audioSource.Play();
        }

        else
        {
            speed = 1.5f;
            animator.SetFloat("Walk", stickL.y);
            animator.SetBool("Run", false);
            run = false;
            audioSource.Stop();
        }
    }
   
    void Saltar()
    {

       /*if(isGrounded && velocity.y < 0f)
        {
            print(velocity.y);
            velocity.y = -2.5f;
        }
       */        

        if(isGrounded && !rodar)
        {
            animator.SetBool("Saltar", true);
            animator.SetBool("isGrounded", false);
            velocity.y = Mathf.Sqrt(3 * -2 * gravity);
            saltando = true;
        }

        /*
        else if(isGrounded )
        {
            animator.SetBool("Saltar", false);
            animator.SetBool("isGrounded", true);
        }
        */

        /*if (cc.isGrounded && rodar == false)
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
        */
    }

    public void Andar()
    {
        
        float fwSpeed = stickL.y;
        
        float fwSpeedRight = stickL.x;
        /*
        Vector3 dir = transform.TransformDirection(Vector3.forward); // Darle valor a la direccion donde queramos mover el character controller mas adelante.
        Vector3 dirRight = transform.TransformDirection(Vector3.right);

        cc.SimpleMove(dir * fwSpeed * speed); // Mover el character controller.

        transform.Rotate(0, stickL.x * rotSpeed, 0);

        moveDirection.y -= gravity * Time.deltaTime;

        cc.Move(moveDirection * Time.deltaTime);
        */

        /*
        moveDirection.y -= gravity * Time.deltaTime;
        cc.Move(moveDirection * Time.deltaTime);
        */
        Vector3 direction = new Vector3(stickL.x, 0f, stickL.y);

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            cc.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if (stickL.y != 0f)
        {
            animator.SetFloat("Walk", 1f);
        }
        else
        {
            animator.SetFloat("Walk", stickL.y);
        }

        if (stickL.x != 0f)
        {
            animator.SetFloat("Walk", 1f);
        }
        else
        {
            animator.SetFloat("Walk", stickL.y);
        }

        /*
        else if (stickL.y < 0f)
        {
            animator.SetFloat("Walk", stickL.y);
        }

        else if (stickL.y == 0 && stickL.x != 0f)
        {
            animator.SetFloat("Walk", stickL.x);
        }
        */
          
        if (rodar)
        {
            fwSpeed = 1f;
        }

        /*
        else if(stickL.y < 0.9 && stickL.y > 0.0000001f)
        {
            fwSpeed = 1f;
        }
     
        else if(stickL.y == 0f && stickL.x != 0f)
        {
            fwSpeed = 1f;
        }
        */

        /*
        else
        {
            fwSpeed = stickL.y;
        }
        */
        /*
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
        */

       
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
        live = false;
        Invoke("BoolMuerto", 2.5f);
        print(live);
        Invoke("Reiniciar", 3f);
    }

    void Reiniciar()
    {
        SceneManager.LoadScene(1);
    }

    void Escalada()
    {
        print("hOlas");
    }

    /*
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Escalada")
        {
            Escalada();
        }
    }
    */
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Agua")
        {
            Muerto();
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
