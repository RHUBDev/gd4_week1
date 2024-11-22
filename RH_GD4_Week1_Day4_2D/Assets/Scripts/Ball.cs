using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            rig.AddForce(Vector3.right * 1);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            rig.AddForce(Vector3.right * -1);
        }
    }
}
