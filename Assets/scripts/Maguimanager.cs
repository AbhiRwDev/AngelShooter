using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Maguimanager : MonoBehaviour
{
    [SerializeField] public GunScript gun;
    public Image[] bulletSprites;
    public Sprite[] placeSprite;
    [SerializeField] Color transparent;
    [SerializeField]private int temp;
    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<GunScript>();
        MagUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MagUpdate()
    {
        for (int i = 0; i < gun.BulletMag.Length ; i++)
        {
           
            if (gun.BulletMag[i] == 0)
            {
                bulletSprites[gun.BulletMag.Length-1-i].sprite = placeSprite[0];
            }
            else if (gun.BulletMag[i] == 1)
            {
                bulletSprites[ gun.BulletMag.Length-1-i].sprite = placeSprite[1];
            }
            else if (gun.BulletMag[i] == 2)
            {
                bulletSprites[gun.BulletMag.Length-1-i].sprite = placeSprite[2];
            }
            else
            {
                bulletSprites[i].sprite = null;
            }

        }
    }
    public void RemoveBullet()
    {
        
        bulletSprites[bulletSprites.Length - 1-temp].color = transparent;
        temp++;
        
        MagUpdate();
    }
}
