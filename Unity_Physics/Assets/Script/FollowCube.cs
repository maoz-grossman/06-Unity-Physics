using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCube : MonoBehaviour
{
    [SerializeField]
    private GameObject _cube;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = new Vector3(_cube.transform.position.x, transform.position.y , _cube.transform.position.z-9f);

    }

}
