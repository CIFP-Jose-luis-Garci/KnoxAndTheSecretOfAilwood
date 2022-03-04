using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminarBichos : MonoBehaviour
{

    Zumby zumby;
    Collider colliderArma;

    [SerializeField] GameObject vida;
    [SerializeField] GameObject caja;
    [SerializeField] GameObject impacto;
    [SerializeField] GameObject estela;
    [SerializeField] Rigidbody zumbyRigid;

    // Start is called before the first frame update
    void Start()
    {
        colliderArma = GameObject.Find("guja").GetComponent<BoxCollider>();
        // zumbyRigid = GameObject.Find("Body").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DesactivarCollider()
    {
        colliderArma.enabled = false;
    }

    void ActivarCollider()
    {
        colliderArma.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemigo")
        {
            Zumby zumby;
            zumby = other.gameObject.GetComponent<Zumby>();
            zumby.SendMessage("RecibirGolpe");
            // zumbyRigid.AddForce(0, 1, 0);
            DesactivarCollider();
            Instantiate(impacto, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            
            Invoke("ActivarCollider", 2f);

            print(zumby.lifes);

            if (zumby.lifes <= 0)
            {
                Destroy(other.gameObject);
            }
        }

        if(other.gameObject.tag == "Destruible")
        {
            Destroy(other.gameObject);
            Instantiate(vida, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }
}
