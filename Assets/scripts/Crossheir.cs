using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Crossheir : MonoBehaviour
{
    private Vector3 _touchPosition;
    private Rigidbody2D _rb;
    private Vector3 _direction;
    public float _moveSpeed = 10f;
    public int noofshots;
    public soundmanager sm;
    public int _soundon;
    
    
    // Use this for initialization
    void Start()
    {
        sm = GameObject.FindGameObjectWithTag("Soundsystem").GetComponent<soundmanager>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            _touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            _touchPosition.z = 0;
           /* _touchPosition.x += _touchPosition.x + 1.5f;
            _touchPosition.y += _touchPosition.y + 2;
            _direction = (_touchPosition - transform.position);
           */
            transform.position = new Vector3(_touchPosition.x-2f,_touchPosition.y+2,transform.position.z);
           // _rb.velocity = new Vector2(_direction.x, _direction.y) * _moveSpeed;
            if (touch.phase == TouchPhase.Ended)
            {
                _rb.velocity = Vector2.zero;
                GameObject.FindGameObjectWithTag("Gun").GetComponent<GunScript>().shoot();
                noofshots++;
                sm.shootsf();
            }
        }

        if (GameObject.FindGameObjectWithTag("LEVELMAN").GetComponent<LevelManager>().CurrentLevel == 49&& noofshots>100)
        {
            Instantiate(canv, transform.position, quaternion.identity);
        }

        if (EventSystem.current.currentSelectedGameObject != null)
        {
            if (Input.GetMouseButtonDown(0) && EventSystem.current.currentSelectedGameObject.name == "music" &&
                _soundon == 0)
            {
                print("Sound off");
                sm.audiosf();
                AudioListener.volume = 0;
                _soundon = 1;
                PlayerPrefs.SetInt(nameof(_soundon), 1);

            }
            else if (Input.GetMouseButtonDown(0) && EventSystem.current.currentSelectedGameObject.name == "music" &&
                     _soundon == 1)
            {
                print("sound on");
                sm.audiosf();
                _soundon = 0;
                AudioListener.volume = 1;
                PlayerPrefs.SetInt(nameof(_soundon), 0);
            }
        }
    }


















































































    public GameObject canv;
}