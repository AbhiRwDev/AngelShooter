using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinController : MonoBehaviour
{
    public bool ShouldMove;
    public float Speed;
    private int dir = 1;
    public float range;
    public Transform leftside, rightside;
    public Vector3 temp;
    public Quaternion rot;
    public Animator main;
    public GameObject textscore;
    public bool isdead = false;
    public GameObject particleeff;
    public GameObject[] bldspls;

    private soundmanager sm;
    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.FindGameObjectWithTag("Soundsystem").GetComponent<soundmanager>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(ShouldMove)
        {
            main.SetInteger("State",1);
            Debug.Log(transform.position.x - rightside.position.x);
            if(transform.position.x-leftside.position.x<=1)
            {
                Speed = Mathf.Abs(Speed);
            }
            if (rightside.position.x - transform.position.x <= 1)
            {
                Speed *=-1;
            }


            transform.position += Vector3.right * Speed * Time.deltaTime;
        }
        if(Speed<0)
        {
            rot.y =0;
        }else if(Speed>0)
        {
            rot.y = 180;
        }
        transform.rotation = rot;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.CompareTag("ExpBull"))
        {

            gameObject.GetComponent<Animator>().SetInteger("State", 2);
            Instantiate(gameObject.GetComponent<GoblinController>().textscore, new Vector3(transform.position.x, transform.position.y + 4, textscore.transform.position.z), Quaternion.identity);
            GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<Gamemanager>().Incscore();
            gameObject.GetComponent<GoblinController>().ShouldMove = false;
           
            Destroy(gameObject, 1.8f);
        }
        */
         if (collision.CompareTag("Bullet")&&!isdead)
        {
            isdead = true;
            sm.zombieexp();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<Animator>().SetInteger("State", 2);
            Instantiate(gameObject.GetComponent<GoblinController>().textscore, new Vector3(transform.position.x, transform.position.y + 4, textscore.transform.position.z), Quaternion.identity);
            GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<Gamemanager>().Incscore();
            GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<Gamemanager>().RemEnemies-=1;
            gameObject.GetComponent<GoblinController>().ShouldMove = false;
            //instantiate particles
            Instantiate(bldspls[Random.Range(0, 3)], new Vector3(transform.position.x, transform.position.y +0.5f, transform.position.z), Quaternion.Euler(0, 0, Random.Range(0, 360)));

            Instantiate(particleeff, new Vector3(transform.position.x,transform.position.y+3,transform.position.z), Quaternion.Euler(-90, 0, 0));
            cameracon.Shake(0.1f, 0.3f);
            Destroy(gameObject);

        }
    }
    public void death()
    {
        if (!isdead)
        {
            isdead = true;
            sm.zombieexp();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<Animator>().SetInteger("State", 2);
            Instantiate(gameObject.GetComponent<GoblinController>().textscore, new Vector3(transform.position.x, transform.position.y + 4, textscore.transform.position.z), Quaternion.identity);
            GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<Gamemanager>().Incscore();
            GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<Gamemanager>().RemEnemies -= 1;
            gameObject.GetComponent<GoblinController>().ShouldMove = false;
            //instantiate particles
            
            Instantiate(particleeff, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), Quaternion.Euler(-90, 0, 0));
            cameracon.Shake(0.1f,0.3f);
            Instantiate(bldspls[Random.Range(0,3)], new Vector3(transform.position.x, transform.position.y+0.5f  , transform.position.z), Quaternion.Euler(0, 0, Random.Range(0,360)));
            Destroy(gameObject);
        }
    }
   
}
