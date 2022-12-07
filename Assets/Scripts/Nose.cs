using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nose : MonoBehaviour
{
    public GameObject hitEffect;
    private void Awake()
    {
        hitEffect = Resources.Load<GameObject>("Hit_03");
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("MainPlayer"))
        {
            Debug.Log("Hit");
            collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(50f, collision.contacts[0].point, 10f);
            Instantiate(hitEffect, collision.contacts[0].point, Quaternion.identity);
            PlayerHandler.Instance.HP -= 10;
        }
    }
}
