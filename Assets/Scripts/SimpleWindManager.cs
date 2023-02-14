using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWindManager : MonoBehaviour
{
    public GameObject WindPointer;
    public Vector2 CurrentWindDirection = Vector2.zero;
    public float WindChangeTimer = 5.0f;

    public float cacheTimer = 0.0f;
    public Vector2 prevDirection;
    public Vector2 nextDirection;

    void Start()
    {
        //CurrentWindDirection = Vector2.right;
    }

    void Update()
    {
        if(cacheTimer > WindChangeTimer)
        {
            cacheTimer = 0.0f;
            prevDirection = nextDirection;
            nextDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            nextDirection.Normalize();
        }

        CurrentWindDirection = Vector2.Lerp(prevDirection, nextDirection, cacheTimer / WindChangeTimer);

        WindPointer.transform.LookAt(new Vector3(CurrentWindDirection.x, 0.0f, CurrentWindDirection.y));

        cacheTimer += Time.deltaTime;
    }

    public Vector2 GetWindDirection()
    {
        return CurrentWindDirection;
    }
}
