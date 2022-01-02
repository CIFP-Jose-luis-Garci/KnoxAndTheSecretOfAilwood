using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesInicio : MonoBehaviour
{
    public void NuevaPartida()
    {

        SceneManager.LoadScene(1);

    }

    public void Cargar()
    {
        SceneManager.LoadScene(1);

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

}
