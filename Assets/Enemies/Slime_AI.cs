using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slime_AI : MonoBehaviour
{
    private NavMeshAgent nav;
    public Transform Target;
    public float minAngryDist;
    public float minAttackDist;
    public float AtkInterval;
    private float cooldown;
    public int damage;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Target.gameObject)
        {
            float dist = Vector3.Distance(Target.position, transform.position);
            if (dist <= minAttackDist)
            {
                if (cooldown >= AtkInterval)
                {
                    Target.GetComponent<Health>().DamageMe(damage);
                    cooldown = 0;
                }
                nav.enabled = false;
            }
            else
            {
                nav.enabled = true;
                nav.SetDestination(Target.position);
            }
        }
        if (cooldown <= AtkInterval)
            cooldown += Time.deltaTime;
    }
}
