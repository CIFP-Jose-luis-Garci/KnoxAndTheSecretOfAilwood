using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
<<<<<<< Updated upstream
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

=======


public class BotonesInicio : MonoBehaviour
{
    [SerializeField] GameObject cameraTrail;
    [SerializeField] GameObject menuCamera;
    public AudioMixer audioMixer;

    private void Start()
    {
        menuCamera.SetActive(true);
        cameraTrail.SetActive(false);
    }

    public void Inicio()
    {

        SceneManager.LoadScene(0);
        
    }
    public void NuevaPartida()
    {
        cameraTrail.SetActive(true);
        gameObject.SetActive(false);
        Invoke("EscenaJuego", 2f);
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
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

=======
        cameraTrail.SetActive(true);
        Invoke("EscenaJuego", 2f);
        
>>>>>>> Stashed changes
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
    public void SetVolumeMaster(float volumeMaster)
    {
        audioMixer.SetFloat("VolumeMaster", Mathf.Log10(volumeMaster) * 20);
    }
    public void SetVolumeMusic(float volumeMusic)
    {
        audioMixer.SetFloat("VolumeMusic", Mathf.Log10(volumeMusic) * 20);
    }
    public void SetVolumeEffects(float volumeEffects)
    {
        audioMixer.SetFloat("VolumeEffects", Mathf.Log10(volumeEffects) * 20);
    }
    public void EscenaJuego()
    {
        SceneManager.LoadScene(1);
        MusicScript.inst.Pausar();
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
