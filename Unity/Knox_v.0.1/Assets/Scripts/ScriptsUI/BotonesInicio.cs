using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class BotonesInicio : MonoBehaviour
{
    [SerializeField] GameObject menuCamera;
    [SerializeField] GameObject trailCamera;
    public AudioMixer audioMixer;


    private void Start()
    {
        trailCamera.SetActive(false);
        gameObject.SetActive(true);
    }
    public void MenuInicio()
    {
        SceneManager.LoadScene(0);

    }
    public void Partida()
    { 
        trailCamera.SetActive(true);
        gameObject.SetActive(false);
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
