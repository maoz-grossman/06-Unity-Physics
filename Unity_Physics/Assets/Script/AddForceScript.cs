using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceScript : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    private float _speed = 10f;
    [SerializeField]
    private float _angularSpeed = 10f;

    private float _Velocity;
    private float AngularVelocity;
  


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
       _Velocity = rb.velocity.magnitude;
        AngularVelocity = rb.angularVelocity.magnitude;
        rb.AddForce(Vector3.forward * _speed,ForceMode.Force);
        rb.AddTorque(Vector3.forward*_angularSpeed);
    }

    void OnGUI()
    {
        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
        fontSize.fontSize = 22;
        fontSize.normal.textColor = Color.black;
        GUI.Label(new Rect(100, 0, 200, 50), "Speed: " +_Velocity, fontSize);
        GUI.Label(new Rect(100, 50, 200, 50), "AngularSpeed: " +AngularVelocity.ToString("F2"), fontSize);
    }

}
