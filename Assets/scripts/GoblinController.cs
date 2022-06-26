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
    // Start is called before the first frame update
    void Start()
    {
       
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
        if (collision.CompareTag("ExpBull"))
        {

            gameObject.GetComponent<Animator>().SetInteger("State", 2);
            Instantiate(gameObject.GetComponent<GoblinController>().textscore, new Vector3(transform.position.x, transform.position.y + 4, textscore.transform.position.z), Quaternion.identity);
            GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<Gamemanager>().Incscore();
            gameObject.GetComponent<GoblinController>().ShouldMove = false;
            Destroy(collision.gameObject);
            Destroy(gameObject, 1.8f);
        }
        else if (collision.CompareTag("Bullet"))
        {

            gameObject.GetComponent<Animator>().SetInteger("State", 2);
            Instantiate(gameObject.GetComponent<GoblinController>().textscore, new Vector3(transform.position.x, transform.position.y + 4, textscore.transform.position.z), Quaternion.identity);
            GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<Gamemanager>().Incscore();
            gameObject.GetComponent<GoblinController>().ShouldMove = false;
            Destroy(gameObject, 1.8f);

        }
    }
   
}
