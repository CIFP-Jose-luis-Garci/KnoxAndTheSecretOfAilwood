using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class BotonesPausa : MonoBehaviour
{
    public bool gamePaused = false;
    public GameObject UIPause;
    public GameObject UIPanel;
    public GameObject UIOptions;
    public GameObject botonSelectMenu, botonSelectOptions;
    

    

    private void Start()
    {
        UIPause.SetActive(false);
        UIPanel.SetActive(false);
        UIOptions.SetActive(false);

    }


    public void MenuInicio()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    void Update()
    { 
           
        
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

    public void Resume()
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
        EventSystem.current.SetSelectedGameObject(botonSelectMenu);

    }

    public void MenuOptions()
    {
        UIPause.SetActive(false);
        UIOptions.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(botonSelectOptions);
    }
    public void VolverMenu()
    {
        UIPause.SetActive(true);
        UIOptions.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(botonSelectMenu);

    }
    

}
