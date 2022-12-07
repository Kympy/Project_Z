using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotation : MonoBehaviour
{
    private void Update()
    {
        transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
        Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
    }
}
