using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesInicio : MonoBehaviour
{
    [SerializeField] GameObject menuCamera;
    [SerializeField] GameObject trailCamera;


    private void Start()
    {
        trailCamera.SetActive(false);
    }
    public void NuevaPartida()
    { 
        trailCamera.SetActive(true);
        Invoke("InicioJuego", 2f);

    }

    public void Cargar()
    {
        
        Invoke("InicioJuego", 2f);

    }

    public void Extras()
    {
        SceneManager.LoadScene(2);

    }

    public void Ajustes()
    {
        SceneManager.LoadScene(3);

    }

    public void Salir()
    {
        Application.Quit();

    }
    public void InicioJuego()
    {
        SceneManager.LoadScene(1);
        MusicScript.inst.Pausar();
    }

}
