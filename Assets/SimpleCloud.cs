using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCloud : MonoBehaviour
{
    public SimpleWindManager WindManager;

    public float CloudSpeedMultiplier = 1.0f;
    public Vector2 CloudDirection;

    void Start()
    {
        WindManager = FindAnyObjectByType<SimpleWindManager>();
    }

    void Update()
    {
        CloudDirection = WindManager.GetWindDirection();

        transform.position += new Vector3(CloudDirection.x, 0.0f, CloudDirection.y) * CloudSpeedMultiplier * Time.deltaTime;
    }
}
