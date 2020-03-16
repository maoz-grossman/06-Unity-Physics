using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bhereshit : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField]
    private float _distance;
    [SerializeField]
    private float _addDrag = 4;
    [SerializeField]
    private GameObject _explosion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, _distance);
        if (hit.collider != null)
        {
            rb.drag = _addDrag;
        }
        //To see the Gizmo of the ray 
        Debug.DrawRay(transform.position, -Vector2.up * _distance, Color.red);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("The magnitude is" + rb.velocity.magnitude);


        if (rb.velocity.magnitude > 1)
        {
            StartCoroutine(Explosion());
        }
    }

    IEnumerator Explosion()
    {
        _explosion.SetActive(true);
        yield return new WaitForSeconds(0.68f);
        Destroy(this.gameObject);
    }
}
