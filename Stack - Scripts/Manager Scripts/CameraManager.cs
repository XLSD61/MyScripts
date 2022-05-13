using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
//using DorukEvents;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Camera cam;

    [SerializeField] float shakeTime;
    [SerializeField] float shakePower;
    [SerializeField] bool isSecondCamVersion = false;
    [SerializeField] bool isSecondStartCam = false;
    [SerializeField] Vector3 secondCamPos;
    [SerializeField] Quaternion secondCamRot;
    Vector3 camPos;
    private void OnEnable()
    {
        EventManager.GameCameraLevelEndPos += SetCameraLevelEndPos;
        EventManager.GameCameraLevelStartPos += CameraStartPos;
        EventManager.GameCameraParent += CameraParent;
    }

    private void OnDisable()
    {
        EventManager.GameCameraLevelEndPos -= SetCameraLevelEndPos;
        EventManager.GameCameraLevelStartPos -= CameraStartPos;
        EventManager.GameCameraParent -= CameraParent;

    }

    private void Start()
    {
        if (isSecondStartCam)
        {
            cam.transform.position = secondCamPos;
            cam.transform.rotation = secondCamRot;
        }
        camPos = cam.transform.position;
    }

    public void SetCameraShake()
    {
        cam.DOShakePosition(shakeTime, shakePower ,fadeOut : true).OnComplete(() => CameraTransform());
        cam.DOShakeRotation(shakeTime, shakePower, fadeOut : false).OnComplete(()=> CameraRotation());
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
        if (!isSecondCamVersion)
        {
            cam.transform.DOMove(new Vector3(0, 14f, -15), 1f);
            cam.transform.DORotate(new Vector3(20f, 0, 0), 1f);
            cam.DOFieldOfView(47, 1f);
        }
        else
        {
            cam.transform.DOMove(new Vector3(0f, 5.32f, -3.6f), 1f);
            cam.transform.DORotate(new Vector3(10f, -0f, 0), 1f);
            cam.DOFieldOfView(47, 1f);
        }
    }

    public void CameraParent(GameObject parent, bool value)
    {
        cam.transform.SetParent(parent.transform);
        if (value)
        {
            cam.transform.DOLocalMove(new Vector3(0f, 3.4f, 3.1f), 1f);
            cam.transform.DOLocalRotate(new Vector3(10f, 0f, 0), .5f);
            //Debug.Log("Camera Parent Event Call");
        }
        
    }

    public void CameraStartPos()
    {
        CameraTransform();
        CameraRotation();
        cam.fieldOfView = 47;
    }
}
