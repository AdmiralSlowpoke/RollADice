using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    [HideInInspector]
    public Inventory inven;
    public Animator anim;
    public GameObject Arrow;
    public Transform ArrowPoint;
    public float ArrowSpeed;
    public int CurDmg;
    void Start()
    {
        inven = GetComponent<Inventory>();
        anim = GetComponent<Animator>();
        if (PlayerPrefs.HasKey("Damage"))
        {
            CurDmg =(int)(CurDmg * PlayerPrefs.GetFloat("Damage"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inven.CurWeapon)
        {
            if (inven.CurSlot.type == Type.ranged)
                if (Input.GetMouseButtonDown(1))
                {
                    anim.SetTrigger("Shot");
                    GameObject arrow = Instantiate(Arrow, ArrowPoint.transform.forward, Quaternion.identity);
                    arrow.transform.rotation = Quaternion.Euler(90, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
                    arrow.transform.position = ArrowPoint.position;
                    arrow.GetComponent<Rigidbody>().AddForce(ArrowPoint.forward * ArrowSpeed);
                    arrow.GetComponent<ArrowPiercing>().dmg = CurDmg;
                }
            if(inven.CurSlot.type == Type.melee)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    anim.SetTrigger("Attack");
                    Collider[] col = Physics.OverlapSphere(transform.position, 2);
                    foreach(Collider enemy in col)
                        if(enemy.GetComponent<Health>())
                            if(enemy.tag != "Player")
                                enemy.GetComponent<Health>().DamageMe(CurDmg);
                }
            }
        }
    }
}
