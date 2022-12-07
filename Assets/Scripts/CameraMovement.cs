using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform followTarget = null;
    private Transform zoomFollowTarget = null;
    [SerializeField] private Vector3 cameraOffset = new Vector3(0f, 0.76f, -6.91f);
    [SerializeField] private Vector3 zoomOffset = new Vector3(0f, 0.4f, -3f);
    private float followSpeed = 6f;
    private void Follow()
    {
        if (followTarget == null) return;
        if (PlayerHandler.Instance.IsAim) return;

        transform.position = Vector3.Lerp(transform.position, followTarget.TransformPoint(cameraOffset), Time.deltaTime * followSpeed);
        //transform.position = followTarget.TransformPoint(cameraOffset);
        //transform.LookAt(followTarget);
    }
    private void Zoom()
    {
        if (PlayerHandler.Instance.IsAim == false) return;

        transform.position = Vector3.Lerp(transform.position, zoomFollowTarget.TransformPoint(zoomOffset), Time.deltaTime * followSpeed);
        //transform.position = zoomFollowTarget.TransformPoint(zoomOffset);
        //transform.LookAt(zoomFollowTarget);
    }
    [SerializeField] private Vector3 startRotation;

    private void Start()
    {
        followTarget ??= GameObject.Find("Look").transform;
        zoomFollowTarget ??= GameObject.Find("ZoomLook").transform;
        transform.rotation = Quaternion.Euler(startRotation);
    }
    private void FixedUpdate()
    {
        if (followTarget == null) return;

        Follow();
        Zoom();
        Debug.DrawLine(transform.position, followTarget.position, Color.green);
    }
    private void LateUpdate()
    {
        //Follow();
        //Zoom();
        if (PlayerHandler.Instance.IsAim)
        {
            transform.LookAt(zoomFollowTarget);
        }
        else
        {
            transform.LookAt(followTarget);
        }
    }
}
