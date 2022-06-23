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
}
