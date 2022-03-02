using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesPausa : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject UIPause;
    public GameObject UIPanel;
    public GameObject UIOptions;
    

    

    private void Start()
    {
        
        
    }

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
    void Update()
    { 
           
        
    }

    void Resume()
    {
        UIPause.SetActive(false);
        UIPanel.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
        
    }
    void Pause()
    {
        UIPause.SetActive(true);
        UIPanel.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
        
    }
    public void PauseScreen()
    {
        if (gamePaused)
        {
            Resume();

        }
        else
        {
            Pause();
        }
    }
    
    


}
