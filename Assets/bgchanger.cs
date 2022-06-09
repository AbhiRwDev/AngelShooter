using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgchanger : MonoBehaviour
{
    public Sprite[] Bgs;
    // Start is called before the first frame update
    void Start()
    {
        int i = Random.Range(0,Bgs.Length-1);
        gameObject.GetComponent<SpriteRenderer>().sprite = Bgs[i];
    }

    // Update is called once per frame
  
}
