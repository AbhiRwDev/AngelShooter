using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gcollider : MonoBehaviour
{
    public Animator MainBody;
    public GameObject Main;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public void Death()
    {
       MainBody.SetInteger("State",2);
        GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<Gamemanager>().RemEnemies -= 1;
        GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<Gamemanager>().Incscore();
        Main.GetComponent<GoblinController>().ShouldMove = false;
        Destroy(Main, 1.8f);
    }
}
