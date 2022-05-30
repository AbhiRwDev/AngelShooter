using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceCount : MonoBehaviour
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
        if (collision.collider.tag == WallKaTag)
        {
            if (MaxBounces < 0)
            {
                Destroy(gameObject);
            }
            MaxBounces -= 1;
        }
    }
    public void shoot(int Speed, Vector2 dire)
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(dire.normalized * Speed * Time.fixedDeltaTime, ForceMode2D.Impulse);

    }
}
