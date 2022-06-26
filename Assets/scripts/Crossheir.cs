using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossheir : MonoBehaviour
{
    private Vector3 _touchPosition;
    private Rigidbody2D _rb;
    private Vector3 _direction;
    public float _moveSpeed = 10f;
    // Use this for initialization
    void Start()
    {
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
            }
        }
    }
}