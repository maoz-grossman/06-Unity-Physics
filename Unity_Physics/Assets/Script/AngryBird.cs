using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AngryBird : MonoBehaviour
{
    private bool _isPressed = false;
    private Rigidbody2D rb;
    [SerializeField]
    private Rigidbody2D hook;
    public float releaseTime = .15f;
    public float maxDragDistance = 2f;
    static public int HIGH_SCORE = 0;
    static public int SCORE_FROM_PREV_ROUND = 0;
    public int score = 0;
    private bool _isScore = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        HIGH_SCORE = PlayerPrefs.GetInt("ProspectorHighScore");
        score = HIGH_SCORE;
    }



    void Update()
    {
        //If we currantky pressing the mouse down 
        if (_isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
                rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
            else
                rb.position = mousePos;
        }
    }



    private void OnMouseDown()
    {
        _isPressed = true;
        rb.isKinematic = true;
        //mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        //mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }



    private void OnMouseUp()
    {
        _isPressed = false;
        rb.isKinematic = false;
        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "boundery")
        {
            if (!_isScore)
                AddScore(_isScore);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (other.tag == "Score")
        {
            _isScore = true;
            AddScore(_isScore);
        }
    }

    private void AddScore(bool Addscore)
    {
        if (Addscore)
        {
            score++;
            PlayerPrefs.SetInt("ProspectorHighScore", score);
            print("Score: " + score);
        }
        else
        {
            score = 0;
            PlayerPrefs.SetInt("ProspectorHighScore", score);
            print("Score: " + score);
        }

    }

    void OnGUI()
    {
        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
        fontSize.fontSize = 16;
        fontSize.normal.textColor = Color.black;
        GUI.Label(new Rect(100, 0, 200, 50), "Score: " + score, fontSize);
    }


}
