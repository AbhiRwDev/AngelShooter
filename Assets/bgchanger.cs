using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bgchanger : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] bgs;
    void Start()
    {
        gameObject.GetComponent<Image>().sprite = bgs[Random.Range(0, bgs.Length)];
    }

  
}
