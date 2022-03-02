using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class BotonesInicio : MonoBehaviour
{
    [SerializeField] GameObject menuCamera;
    [SerializeField] GameObject trailCamera;
    public AudioMixer audioMixer;
    //PanelesMenu
    public GameObject UIPause;
    public GameObject UIOptions;
    public GameObject botonSelectMenu, botonSelectOptions;


    private void Start()
    {
        trailCamera.SetActive(false);
        gameObject.SetActive(true);
        UIPause.SetActive(true);       
        UIOptions.SetActive(false);
        EventSystem.current.SetSelectedGameObject(botonSelectMenu);
    }
    public void MenuInicio()
    {
        UIPause.SetActive(true);
        UIOptions.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(botonSelectMenu);

    }
    public void Partida()
    { 
        trailCamera.SetActive(true);
        gameObject.SetActive(false);
        Invoke("InicioJuego", 2f);

    }

    public void Extras()
    {
        //SceneManager.LoadScene(2);

    }

    public void Ajustes()
    {
        UIPause.SetActive(false);
        UIOptions.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(botonSelectOptions);

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

    public void SetVolumeMaster(float volumeMaster)
    {
        audioMixer.SetFloat("volumeMaster", Mathf.Log10(volumeMaster) * 20);
    }

    public void SetVolumeMusic(float volumeMusic)
    {
        audioMixer.SetFloat("volumeMusic", Mathf.Log10(volumeMusic) * 20);
    }

    public void SetVolumeEffects(float volumeEffects)
    {
        audioMixer.SetFloat("volumeEffects", Mathf.Log10(volumeEffects) * 20);
    }
}
