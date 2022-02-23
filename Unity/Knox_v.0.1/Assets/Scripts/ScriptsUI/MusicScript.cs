using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public static MusicScript inst;
    AudioSource audioSource;
    // Start is called before the first frame update
    private void Awake()
    {   
        if(MusicScript.inst == null)
        {   //Solo se Instancia la Primera vez.(Evita instanciaciones continuas de este gameobject)
            MusicScript.inst = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public void Pausar()
    {
        audioSource.Pause();
    }
    public void Reanudar()
    {
        audioSource.UnPause();
    }
    


}
