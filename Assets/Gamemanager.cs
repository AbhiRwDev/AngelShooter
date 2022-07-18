using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gamemanager : MonoBehaviour
{
    public int score;
    public GunScript gs;
  
    [SerializeField] GameObject Winpanel,Losepanel;
    [SerializeField]public int RemEnemies,RemBullets;
    private bool haswon=false;
    public GameObject[] stars;
    public int StarTh,Goblinworth;
    private BulletBounceCount[] bnos;
    private GoblinController[] gb;
    public int rbu;
    public Text scoretxt;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920,1080,FullScreenMode.FullScreenWindow);
        Application.targetFrameRate = 60;
        gs = GameObject.FindGameObjectWithTag("Gun").GetComponent<GunScript>();
        gb = GameObject.FindObjectsOfType<GoblinController>();
        RemEnemies = gb.Length;
        RemBullets = gs.BulletMag.Length;
       

    }

    // Update is called once per frame
    void Update()
    {
        bnos = GameObject.FindObjectsOfType<BulletBounceCount>();
        
        /* int i = 0;
         foreach (var item in bnos)
         {
             i++;
             rbu = i;
         }
        */
        rbu = bnos.Length;
        
        if(scoretxt!=null)
        {
           scoretxt.text= score.ToString();
        }
        
        
    }
    private void LateUpdate()
    {
        if (RemEnemies <= 0 && !haswon)
        {
            gs.canshoot = false;

            RemBullets = -gs.CurrentBull + gs.BulletMag.Length;
            score = score + RemBullets * 3000;
            haswon = true;
            Invoke("win", 2f);
            

        }
        else if (RemEnemies>0&& !haswon)
        {
            if (gs.BulletMag.Length-gs.CurrentBull<=0)
            {
                if (rbu<=0)
                {
                    gs.canshoot = false;
                    haswon = true;
                    Invoke("lose", 2f);


                }
            }

        }
    }
    public void win()
    {

        Winpanel.SetActive(true);
        if(score>StarTh)
        {
            for (int i = 0; i < 3; i++)
            {
                stars[i].SetActive(true);
            }
        }else if(score>StarTh-5000&&score<StarTh)
        {
            for (int i = 0; i < 2; i++)
            {
                stars[i].SetActive(true);
            }
        }
        else
        {
           
                stars[0].SetActive(true);
            
        }
    }
    public void lose()
    {
        Losepanel.SetActive(true);
    }
    public void Incscore()
    {
        score += Goblinworth;
    }
}
