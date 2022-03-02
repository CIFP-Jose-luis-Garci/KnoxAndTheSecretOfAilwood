using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Final : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void FinalJuego()
    {
        SceneManager.LoadScene(3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Jugador")
        {
            FinalJuego();
        }
    }
}
