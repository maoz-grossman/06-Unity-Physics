using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDoodle : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2f;
    Collision2D mycol;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
        
    }

    // Update is called once per frame
    void Update()
    {

    }
   

    //private void OnCollisionEnter2D()
    //{
    //    print("ouch!");
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("outch!");
        if (collision.gameObject.name == "Doodler")
        {
            _speed = Mathf.Max(_speed, collision.relativeVelocity.x);
            print("Speed " + _speed);
        }
        if (collision.gameObject.tag == "Platform")
            rb.freezeRotation = false;
    }
}
