using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gamemanager : MonoBehaviour
{
    public int score;
    public GunScript gs;
    public GameObject[] goblins;
    [SerializeField] GameObject Winpanel,Losepanel;
    [SerializeField]public int RemEnemies,RemBullets;
    private bool haswon=false;
    public GameObject[] stars;
    public int StarTh,Goblinworth;
    private BulletBounceCount[] bnos;
    private GameObject[] gb;
    public int rbu;
    public Text scoretxt;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920,1080,FullScreenMode.FullScreenWindow);
        gs = GameObject.FindGameObjectWithTag("Gun").GetComponent<GunScript>();
        goblins = GameObject.FindGameObjectsWithTag("Gbodies");
        RemEnemies = goblins.Length;
        RemBullets = gs.BulletMag.Length;
       

    }

    // Update is called once per frame
    void Update()
    {
        bnos = GameObject.FindObjectsOfType<BulletBounceCount>();
        gb = GameObject.FindGameObjectsWithTag("gbs");
        /* int i = 0;
         foreach (var item in bnos)
         {
             i++;
             rbu = i;
         }
        */
        rbu = bnos.Length;
        RemEnemies = gb.Length;
        if(scoretxt!=null)
        {
           scoretxt.text= score.ToString();
        }
        
        if(RemEnemies<=0&&!haswon)
        {
            gs.canshoot = false;

            RemBullets = -gs.CurrentBull +gs.BulletMag.Length ;
            score = score + RemBullets * 3000;
            
            Invoke("win",2f);
            haswon = true;

        }else if(gs.CurrentBull>=gs.BulletMag.Length&&RemEnemies>0&&rbu<1)
        {
            gs.canshoot = false;
            Invoke("lose", 2f);
            lose();
            
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
