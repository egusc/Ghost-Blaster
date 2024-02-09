using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera playerCam;
    [SerializeField] float zoomedInFOV = 10f;
    [SerializeField] float zoomedOutFOV = 40f;
    [SerializeField] float zoomSpeed = 10f;

    private void Update() {
        if(Input.GetMouseButton(1))
        {

            playerCam.m_Lens.FieldOfView = playerCam.m_Lens.FieldOfView = Mathf.Lerp(playerCam.m_Lens.FieldOfView, zoomedInFOV, Time.deltaTime * zoomSpeed);;
        }
        else
        {
            playerCam.m_Lens.FieldOfView = Mathf.Lerp(playerCam.m_Lens.FieldOfView, zoomedOutFOV, Time.deltaTime * zoomSpeed);
            
        }
    }
}
