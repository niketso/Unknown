using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfazVidas : MonoBehaviour {

    public MovePlayer player;
    public int vidasMax = 3;
    //public Text vidas;
    public Image[] healthImages;
    public Sprite[] healthSprites;

    // Update is called once per frame
    void Update()
    {
        for (int i=0;i<vidasMax;i++)
        {
            if (player.vidas<= i)
            {
                healthImages[i].enabled = false;
            }
            else
            {
                healthImages[i].enabled = true;
            }
            
        }

        //vidas.text = player.GetVidas().ToString();
    }

}
