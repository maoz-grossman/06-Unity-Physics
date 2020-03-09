using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class DragObject : MonoBehaviour

{
    private Rigidbody rb;
    private Vector3 mOffset;

    private float mZCoord;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown()

    {
        if (rb.IsSleeping())
        {
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            // Store offset = gameobject world pos - mouse world pos
            mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
            rb.useGravity = false;
            rb.isKinematic = true;
        }
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
        if (rb.IsSleeping())
            transform.position = GetMouseAsWorldPoint() + mOffset;
    }


    void OnMouseUp()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
    }


    void OnGUI()
    {
        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
        fontSize.fontSize = 16;
        fontSize.normal.textColor = Color.black;
        GUI.Label(new Rect(25, 0, 200, 50), "Is sleeping?: " + rb.IsSleeping(), fontSize);
        GUI.Label(new Rect(25, 25, 200, 50), "Is kinematic?: " + rb.isKinematic, fontSize);
        GUI.Label(new Rect(25, 50, 200, 50), "Use Gravity?: " + rb.useGravity, fontSize);
        GUI.Label(new Rect(25, 75,300, 50), "Velocity: (x=" + rb.velocity.x.ToString("F2")+" ,y="+rb.velocity.y.ToString("F2")+" ,z="+rb.velocity.z.ToString("F2")+")", fontSize);
    }

}

