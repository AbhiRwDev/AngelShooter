using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

public class buttonspritechanger : MonoBehaviour
{
    public Sprite[] sprite;
    public int unlocklvls;
    public GameObject[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        unlocklvls= PlayerPrefs.GetInt("unLvls");
        
        for (int i = 0; i < sprite.Length; i++)
        {
            buttons[i].GetComponent<Image>().sprite = sprite[i];
            
        }

        for (int i = buttons.Length-1; i > unlocklvls; i--)
        {
            buttons[i].SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
