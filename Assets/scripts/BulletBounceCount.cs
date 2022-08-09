using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBounceCount : MonoBehaviour
{
    public int MaxBounces;
    public string WallKaTag;
    public int MaxSpeed;
    public GameObject expeff,flasheff;

    public soundmanager sm;
    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.FindGameObjectWithTag("Soundsystem").GetComponent<soundmanager>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = MaxSpeed * (gameObject.GetComponent<Rigidbody2D>().velocity.normalized);

       

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        sm.bouncesf();
        MaxBounces -= 1;
        Instantiate(flasheff, transform.position, Quaternion.identity);
        if (collision.collider.tag == WallKaTag)
        {
            if (MaxBounces < 1)
            {
                if (gameObject.CompareTag("ExpBull"))
                {
                    Collider2D[] colli = Physics2D.OverlapCircleAll(transform.position,4);
                    sm.explo();
                    foreach (var item in colli)
                    {
                        if(item.CompareTag("gbs"))
                        {
                            item.GetComponent<BoxCollider2D>().enabled = false;
                            item.GetComponent<GoblinController>().death();
                            
                            
                        }
                    }
                    Instantiate(expeff, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
                Destroy(gameObject);
            }
           
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("ExpBull"))
        {
            if (collision.CompareTag("gbs"))
            {
                Collider2D[] colli = Physics2D.OverlapCircleAll(transform.position, 4);
                foreach (var item in colli)
                {
                    if (item.CompareTag("gbs"))
                    {
                        item.GetComponent<BoxCollider2D>().enabled = false;
                        item.GetComponent<GoblinController>().death();
                    }
                }
                Instantiate(expeff, transform.position, Quaternion.identity);
                sm.explo();
                Destroy(gameObject);
            }
        }
    }

    public void shoot(int Speed, Vector2 dire)
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(dire.normalized * Speed * Time.fixedDeltaTime, ForceMode2D.Impulse);

    }

}
