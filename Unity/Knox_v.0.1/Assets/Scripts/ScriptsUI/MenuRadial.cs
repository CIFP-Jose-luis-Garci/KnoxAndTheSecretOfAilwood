using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRadial : MonoBehaviour
{
    public GameObject menu;
    public Vector2 moveImput;
    public GameObject[] opcionesM;
    int selectO;

    public GameObject blockDiv;


    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);

        opcionesM = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            opcionesM[i] = transform.GetChild(i).gameObject;

        if(opcionesM[selectO])
        {
            opcionesM[selectO].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            menu.SetActive(true);
        }

        if(menu.activeInHierarchy)
        {
            moveImput.x = Input.mousePosition.x - (Screen.width/2);
            moveImput.y = Input.mousePosition.y - (Screen.width / 2);
            moveImput.Normalize();
        
            if(moveImput != Vector2.zero)
            {
                float grados = Mathf.Atan2(moveImput.y, -moveImput.x) / Mathf.PI;
                grados *= 180;
                grados += 90f;
                if(grados < 0)
                {
                    grados += 360;
                }

                for(int a=0; a< opcionesM.Length; a++)
                {
                    if(grados >a * (360/6)&& grados < (a+1) * (360/6))
                    {
                        selectO = a;
                        blockDiv.transform.rotation = Quaternion.Euler(0, 0, a * (360 / 6));
                    }
                }
            }


        }
    }
}
