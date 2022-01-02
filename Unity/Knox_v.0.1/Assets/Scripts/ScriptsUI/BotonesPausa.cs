using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesPausa : MonoBehaviour
{
    public void Reanudar()
    {

        SceneManager.LoadScene(1);

    }

    public void Guardar()
    {

        SceneManager.LoadScene(0);

    }

    public void Ajustes()
    {

        SceneManager.LoadScene(3);

    }

    public void Inicio()
    {

        SceneManager.LoadScene(0);

    }
}
