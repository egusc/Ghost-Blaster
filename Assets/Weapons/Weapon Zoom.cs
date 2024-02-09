using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera playerCam;
    [SerializeField] float zoomedInFOV = 10f;
    [SerializeField] float zoomedOutFOV = 40f;
    [SerializeField] float zoomSpeed = 10f;

    [SerializeField] float zoomedInSensitivity =  0.5f;
    [SerializeField] float zoomedOutSensitivity = 2f;

    FirstPersonController firstPersonController;


    private void Awake() {
        firstPersonController = GetComponent<FirstPersonController>();
    }

    private void Update() {
        if(Input.GetMouseButton(1))
        {

            playerCam.m_Lens.FieldOfView = playerCam.m_Lens.FieldOfView = Mathf.Lerp(playerCam.m_Lens.FieldOfView, zoomedInFOV, Time.deltaTime * zoomSpeed);;
            firstPersonController.RotationSpeed = zoomedInSensitivity;
        }
        else
        {
            playerCam.m_Lens.FieldOfView = Mathf.Lerp(playerCam.m_Lens.FieldOfView, zoomedOutFOV, Time.deltaTime * zoomSpeed);
            firstPersonController.RotationSpeed = zoomedOutSensitivity;
            
        }
    }
}
