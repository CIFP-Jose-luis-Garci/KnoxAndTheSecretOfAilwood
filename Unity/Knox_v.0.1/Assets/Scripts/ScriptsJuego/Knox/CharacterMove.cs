using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    InpuCr inpuCR;
    CharacterController characterController;

    bool correr = false;
    int speedPlayer = 3;
    Vector2 movPlayer;
    
    Animator animator;
    private int forward;

    private void Awake()
    {
        inpuCR = new InpuCr();

        inpuCR.Knox.Correr.started += _ => correr = true;
        inpuCR.Knox.Correr.canceled += _ => correr = false;

        inpuCR.Knox.Andar.performed += ctx  => movPlayer = ctx.ReadValue<Vector2>(); /* Metemos valor de Andar en variable ctx*/ /* Y si es mayor o igual que 0 le decimos que vea el vector 2 */ // Para coger el valor de movimiento.
        inpuCR.Knox.Andar.canceled += _ => movPlayer = Vector2.zero; // Para resetear el valor cuando no se use jopystick.

    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("Knox").GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Andar();

        print("Despl. en Y = " + movPlayer.y);
    }

    void Andar()
    {
        Vector3 dir = new Vector3(movPlayer.x, 0f, movPlayer.y);
        characterController.SimpleMove(dir * speedPlayer);
        /*
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        characterController.SimpleMove(forward * speedPlayer * movPlayer.y);

        Vector3 right = transform.TransformDirection(Vector3.right);
        characterController.SimpleMove(right * speedPlayer * movPlayer.x);
        */
    }

    private void OnEnable()
    {
        inpuCR.Enable();
    }

    private void OnDisable()
    {
        inpuCR.Disable();
    }
}
