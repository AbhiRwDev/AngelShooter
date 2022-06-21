using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private GameObject Bullet,ExplosiveBullet;
    public float firerate;
    public int Speed,ExplosiveSpeed;
    [SerializeField] private float MinAngle, MaxAngle;
    [SerializeField] private float BulletSplitRange;
    public bool canshoot = true;
    [SerializeField] private Transform Target;
    [SerializeField] private Transform Barrel,Barrel1,Barrel2;
    
    public int[] BulletMag;
    private int CurrentBull;
    private Maguimanager magman;
   
    
    // Start is called before the first frame update
    void Start()
    {
        magman = GameObject.FindGameObjectWithTag("MagManager").GetComponent<Maguimanager>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 euler = transform.rotation.eulerAngles;
        if (transform.rotation.eulerAngles.z > 180)
        {
            euler.z = euler.z - 360;
        }
       


       
        Vector3 dir = Target.transform.position - transform.position;
        euler.z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.right = dir;
        euler.z = Mathf.Clamp(euler.z, MinAngle, MaxAngle);
        transform.eulerAngles = euler;




        if (CurrentBull <= BulletMag.Length - 1)
        {

            if (Input.GetMouseButton(0))
            {
                if (canshoot)
                {

                    
                    StartCoroutine(shoot(BulletMag[CurrentBull]));
                    CurrentBull += 1;
                   
                    magman.RemoveBullet();
                    canshoot = false;

                }
            }
        }
    }

    IEnumerator shoot(int bullettype)
    {
        switch (bullettype)
        {
            case (0):
                var ga = Instantiate(Bullet, Barrel.transform.position, Quaternion.identity);
                ga.GetComponent<Rigidbody2D>().AddForce((Barrel.transform.position - transform.position) * Speed, ForceMode2D.Impulse);
                // ga.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
                yield return new WaitForSeconds(firerate);
                canshoot = true;
                break;
            case (1):
                var TempBull1 = Instantiate(Bullet, Barrel.position, Quaternion.identity);
                TempBull1.GetComponent<Rigidbody2D>().AddForce((Barrel.transform.position - transform.position) * Speed, ForceMode2D.Impulse);
                var TempBull2 = Instantiate(Bullet, Barrel1.position, Quaternion.identity);
                TempBull2.GetComponent<Rigidbody2D>().AddForce((Barrel1.transform.position - transform.position) * Speed, ForceMode2D.Impulse);
                var TempBull3 = Instantiate(Bullet, Barrel2.position, Quaternion.identity);
                TempBull3.GetComponent<Rigidbody2D>().AddForce((Barrel2.position - transform.position) * Speed, ForceMode2D.Impulse);
                // ga.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
                yield return new WaitForSeconds(firerate);
                canshoot = true;
                break;
            case (2):var ExpBull = Instantiate(ExplosiveBullet,Barrel.position,Quaternion.identity);
                ExpBull.GetComponent<Rigidbody2D>().AddForce((Barrel.transform.position - transform.position) * ExplosiveSpeed, ForceMode2D.Impulse);
                yield return new WaitForSeconds(firerate);
                canshoot = true;
                break;

        }
       /* if (bullettype == 1)
        {
           
        }
       */
       
    }
   
}
