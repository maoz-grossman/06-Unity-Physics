using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //Typical movment, moving without Force
    //void Update()
    //{
    //    float horizontal = Input.GetAxis("Horizontal");
    //    transform.Translate(new Vector3(horizontal, 0, 0) * _speed * Time.deltaTime);

    //}

   // Moiving with force
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rb.AddForce(Vector2.right * horizontal * _speed, ForceMode2D.Force);
    }
}
