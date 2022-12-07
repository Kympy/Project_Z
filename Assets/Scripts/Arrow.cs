using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject hitEffect;
    private void Awake()
    {
        GetComponent<Rigidbody>().centerOfMass = transform.GetChild(0).transform.position;
        hitEffect = Resources.Load<GameObject>("Hit_02");
    }
    [SerializeField] private BoxCollider headCol = null;
    public void FlyArrow(float power)
    {
        transform.rotation = Camera.main.transform.rotation;
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(hitEffect, collision.contacts[0].point, Quaternion.identity);
        this.GetComponent<Rigidbody>().isKinematic = true;
        headCol.enabled = false;
        if (collision.gameObject.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 500f, ForceMode.Impulse);
            this.transform.SetParent(collision.gameObject.transform);
            collision.gameObject.GetComponent<Elephant>().HP -= 20;
        }
        this.GetComponentInChildren<TrailRenderer>().enabled = false;
    }
}
