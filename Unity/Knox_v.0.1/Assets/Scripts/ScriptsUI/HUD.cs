using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    //UI Vidas
    [SerializeField] Image lifesImage;
    [SerializeField] Sprite[] lifesSprite;
    StatsKnox statsknox;

    // Start is called before the first frame update
    void Start()
    {
        statsknox = GameObject.Find("Idle").GetComponent<StatsKnox>();
    }

    // Update is called once per frame
    void Update()
    {
        int lifes = statsknox.lifes;
        lifesImage.sprite = lifesSprite[lifes];
        if (lifes <= 0)
        {
            GameObject.Find("CanvasHUD").GetComponent<Canvas>().enabled = false;
        }
    }
}
