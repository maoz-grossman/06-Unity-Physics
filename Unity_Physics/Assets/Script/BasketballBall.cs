using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasketballBall : MonoBehaviour
{
    private Rigidbody2D rb;
    private float _startTime;
    private float _endTime;
    private Vector3 mOffset;
    private float mZCoord;
    private Vector3 mEnd;
    private Vector3 mStart;
    public float ForceAdd = 1300f;
    private int Score = 0;
    private SpringJoint2D sj;
    public float _timeToWait = 2f;


    private void Start()
    {
        sj = GetComponent<SpringJoint2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()

    {
        sj.enabled = false;
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        _startTime = Time.time;
        rb.isKinematic = true;
        mStart = GetMouseAsWorldPoint();

    }



    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }



    void OnMouseDrag()

    {

        //transform.position = GetMouseAsWorldPoint() + mOffset;
        transform.position = GetMouseAsWorldPoint();
    }


    void OnMouseUp()
    {
        _endTime = Time.time;
        rb.isKinematic = false;
        //mEnd = GetMouseAsWorldPoint() + mOffset;
        mEnd = GetMouseAsWorldPoint();
        float timeTO = 1/(_endTime - _startTime);
        Vector3 ForceVec = (mEnd - mStart).normalized;
        rb.AddForce(ForceVec * ForceAdd);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "boundery")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (other.tag == "Platform")
        {
            StartCoroutine(HitTheFlore());
            print("Platform");
        }
    }


    IEnumerator HitTheFlore()
    {
        yield return new WaitForSeconds(_timeToWait);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //void OnGUI()
    //{
    //    GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
    //    fontSize.fontSize = 16;
    //    fontSize.normal.textColor = Color.black;
    //    GUI.Label(new Rect(25, 0, 200, 50), "Is sleeping?: " + rb.IsSleeping(), fontSize);
    //    GUI.Label(new Rect(25, 25, 200, 50), "Is kinematic?: " + rb.isKinematic, fontSize);
    //    GUI.Label(new Rect(25, 75, 300, 50), "Velocity: (x=" + rb.velocity.x.ToString("F2") + " ,y=" + rb.velocity.y.ToString("F2") + " ,z=" + rb.velocity.z.ToString("F2") + ")", fontSize);
    //}
}
