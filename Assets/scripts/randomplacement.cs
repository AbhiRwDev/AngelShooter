using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomplacement : MonoBehaviour
{
    public GameObject[] blocks;
    public float x, y,x1,y1;
    public int placeno;
    // Start is called before the first frame update
    void Start()
    {
        
       
    }
    public void shuff()
    {
        for (int i = 0; i < placeno; i++)
        {
            var b = Instantiate(blocks[Random.Range(0, 2)]);
            b.transform.position = new Vector3(Random.Range(-x, x), Random.Range(-y, y), transform.position.z);
            b.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));

        }
    }
}
