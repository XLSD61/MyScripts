using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
//using DorukEvents;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Camera cam;

   [SerializeField] Vector3 camPos;
    [SerializeField] bool isCamVersion1;
    [SerializeField] bool isCamVersion2;
    [SerializeField] bool isCamVersion3;
    private void OnEnable()
    {
        EventManager.GameCameraLevelEndPos += SetCameraLevelEndPos;
        EventManager.GameCamerePlayPos += CameraPlayPos;
        EventManager.GameCameraLevelStartPos += CameraStartPos;
    }

    private void OnDisable()
    {
        EventManager.GameCameraLevelEndPos -= SetCameraLevelEndPos;
        EventManager.GameCamerePlayPos -= CameraPlayPos;
        EventManager.GameCameraLevelStartPos -= CameraStartPos;

    }

    private void Start()
    {
        if (isCamVersion1)
        {
            cam.transform.position = new Vector3(0, 0, 0);
            cam.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (isCamVersion2)
        {
            cam.transform.position = new Vector3(0, 0, 0);
            cam.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (isCamVersion3)
        {
            cam.transform.position = new Vector3(0, 0, 0);
            cam.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        camPos = cam.transform.position;
    }

    void CameraTransform()
    {
        cam.transform.position = camPos;
       // Debug.Log("Cagrýldý");
    }

    void CameraRotation()
    {
        cam.transform.rotation = Quaternion.Euler(20, 0, 0);
    }

    public void SetCameraLevelEndPos()
    {
        cam.transform.DOMove(new Vector3(0f, 5.32f, -3.6f), 1f);
        cam.transform.DORotate(new Vector3(10f, -0f, 0), 1f);
        cam.DOFieldOfView(47, 1f);
    }
    public void CameraPlayPos()
    {
        cam.transform.DOMove(new Vector3(0f, 18.1f, -15.4f), 1f);
    }
    public void CameraStartPos()
    {
        CameraTransform();
      //  CameraRotation();
       // cam.fieldOfView = 47;
    }
}
