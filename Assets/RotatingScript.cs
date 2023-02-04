using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingScript : MonoBehaviour
{
    public float rotMult = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        this.transform.RotateAroundLocal(Vector3.up, rotMult * xInput);
        this.transform.RotateAroundLocal(Vector3.right, -rotMult * yInput);
    }
}
