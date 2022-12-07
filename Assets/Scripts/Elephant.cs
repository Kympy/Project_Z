using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Elephant : MonoBehaviour
{
    public GameObject DeathEffect;
    public int HP = 1000;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        DeathEffect = Resources.Load<GameObject>("Hit_01");
    }
    private void Update()
    {
        agent.destination = PlayerHandler.Instance.myPlayer.transform.position;
        if (HP < 0)
        {
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
