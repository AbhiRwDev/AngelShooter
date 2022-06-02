using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBounceCount : MonoBehaviour
{
    public int MaxBounces;
    public string WallKaTag;
    public int MaxSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = MaxSpeed * (gameObject.GetComponent<Rigidbody2D>().velocity.normalized);


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        MaxBounces -= 1;
        if (collision.collider.tag == WallKaTag)
        {
            if (MaxBounces < 1)
            {
                Destroy(gameObject);
            }
           
        }
    }
    public void shoot(int Speed, Vector2 dire)
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(dire.normalized * Speed * Time.fixedDeltaTime, ForceMode2D.Impulse);

    }
}
