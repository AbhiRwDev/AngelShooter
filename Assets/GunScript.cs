using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject Bullet;
    public float firerate;
    public int Speed;
    public float MinAngle, MaxAngle;
    public bool canshoot = true;
    public Transform Target;
    public Transform Barrel;
    public Quaternion rot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 euler = transform.rotation.eulerAngles;
        if (transform.rotation.eulerAngles.z > 180)
        {
            euler.z = euler.z - 360;
        }
        Debug.Log(euler.z);


        rot = transform.rotation;
        Vector3 dir = Target.transform.position - transform.position;
        euler.z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.right = dir;
        euler.z = Mathf.Clamp(euler.z, MinAngle, MaxAngle);
        transform.eulerAngles = euler;






        if (Input.GetMouseButton(0))
        {
            if (canshoot)
            {
                StartCoroutine(shoot());
                canshoot = false;
            }
        }
    }

    IEnumerator shoot()
    {
        var ga = Instantiate(Bullet, transform.position, Quaternion.identity);

        ga.GetComponent<Rigidbody2D>().AddForce((Barrel.transform.position - transform.position) * Speed, ForceMode2D.Impulse);
        ga.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        yield return new WaitForSeconds(firerate);
        canshoot = true;

    }
}
