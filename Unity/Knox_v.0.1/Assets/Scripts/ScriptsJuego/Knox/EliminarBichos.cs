using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminarBichos : MonoBehaviour
{

    Zumby zumbyLifes;
    Collider colliderArma;

    [SerializeField] ParticleSystem vida;

    // Start is called before the first frame update
    void Start()
    {
        zumbyLifes = GameObject.Find("Body").GetComponent<Zumby>();
        colliderArma = GameObject.Find("guja").GetComponent<BoxCollider>();
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
            zumbyLifes.lifes -= 20;
            DesactivarCollider();
            Invoke("ActivarCollider", 2f);

            print(zumbyLifes.lifes);

            if (zumbyLifes.lifes <= 0)
            {
                Destroy(other.gameObject);
            }
        }

        if(other.gameObject.tag == "Destruible")
        {
            Destroy(other.gameObject);
            Instantiate(vida);
        }
    }
}
