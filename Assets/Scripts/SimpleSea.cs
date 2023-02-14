using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSea : MonoBehaviour
{
    public SimpleWindManager WindManager;

    public Material myMat;

    void Start()
    {
        myMat = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        //myMat.mainTextureOffset = Time.deltaTime * WindManager.GetWindDirection() * 100;
    }
}
