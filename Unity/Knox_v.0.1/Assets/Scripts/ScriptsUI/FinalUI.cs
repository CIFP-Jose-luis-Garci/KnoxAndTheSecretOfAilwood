using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalUI : MonoBehaviour
{

    // Start is called before the first frame update
  
    public void Salir()
    {
        Application.Quit();
    }
    public void Volveralmenuinicio()
    {
        SceneManager.LoadScene(0);
    }
}
