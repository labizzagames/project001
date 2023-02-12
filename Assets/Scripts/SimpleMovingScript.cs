using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class SimpleMovingScript : MonoBehaviour
{
    public Transform ShipGraphicModel;
    public Transform ShipGraphicModel3D;

    public CinemachineVirtualCamera CMFishing;

    public AudioSource audioSource;

    public AudioClip cameraInSound;
    public AudioClip cameraOutSound;

    public bool bIsFishing = false;

    public float zMovingMult;
    public float zInterpFactor = 0.4f;
    public float rotMovingMult;

    private void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        zInput = Mathf.Clamp(zInput, 0.0f, 1.0f);

        this.transform.position = Vector3.Lerp
            (
            this.transform.position,
            this.transform.position + (this.transform.forward) * zInput * zMovingMult * Time.deltaTime,
            zInterpFactor
            );

        this.transform.Rotate(Vector3.up, rotMovingMult * xInput * Time.deltaTime);

        ShipGraphicModel3D.transform.Rotate(Vector3.up, rotMovingMult * xInput * Time.deltaTime);

        ShipGraphicModel.transform.rotation = Quaternion.Slerp
            (
            Quaternion.identity,
            Quaternion.Euler(0.0f,0.0f,rotMovingMult * Mathf.Sign(xInput)),
            Mathf.Abs(xInput)
            );
    }

    private void Fish()
    {
        float xInput = Input.GetAxis("Horizontal");

        this.transform.Rotate(Vector3.up, rotMovingMult * xInput * Time.deltaTime);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            bIsFishing = !bIsFishing;

            if (bIsFishing)
            {
                audioSource.clip = cameraInSound;
                audioSource.Play();
                CMFishing.Priority = 2;
            }
            else
            {
                audioSource.clip = cameraOutSound;
                audioSource.Play();
                CMFishing.Priority = 0;
            }
        }

        if (!bIsFishing)
            Move();
        else
            Fish();
    }
}
