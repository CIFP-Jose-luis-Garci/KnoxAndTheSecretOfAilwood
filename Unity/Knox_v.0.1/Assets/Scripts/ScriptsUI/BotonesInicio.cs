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
    public void Partida()
    { 
        trailCamera.SetActive(true);
        gameObject.SetActive(false);
        Invoke("InicioJuego", 2f);

    public void Cargar()
    {
        SceneManager.LoadScene(1);

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

    public void SetVolumeEffects(float volumeEffects)
    {
        audioMixer.SetFloat("volumeEffects", Mathf.Log10(volumeEffects) * 20);
    }
}
