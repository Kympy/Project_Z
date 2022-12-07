using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Focus : MonoBehaviour
{
    [SerializeField] private bool isZoom = false;
    private Transform player;
    [SerializeField] private Vector3 offset;
    private void Start()
    {
        player = PlayerHandler.Instance.myPlayer.transform;
    }
    private void Update()
    {
        transform.position = player.position + offset + transform.right * 0.6f;
        //if (isZoom == false)
        //{
        //    transform.position = player.position + offset;
        //}
        //else
        //{
        //    transform.position = player.position + offset + transform.right * 0.6f;
        //}
        transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f));
    }
}
