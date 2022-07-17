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
    public Animator anim;
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
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
                    anim.SetTrigger("Attack");
                    Target.GetComponent<Health>().DamageMe(damage);
                    cooldown = 0;
                }
                nav.enabled = false;
                anim.SetBool("Walk", false);
            }
            else
            {
                nav.enabled = true;
                nav.SetDestination(Target.position);
                anim.SetBool("Walk", true);
            }
        }
        if (cooldown <= AtkInterval)
            cooldown += Time.deltaTime;
    }
}
