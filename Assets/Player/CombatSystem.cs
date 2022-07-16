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
    void Start()
    {
        inven = GetComponent<Inventory>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inven.CurWeapon)
            if(inven.CurWeapon.name == "Bow(Clone)")
                if (Input.GetMouseButtonDown(1))
                {
                    anim.SetTrigger("Shot");
                    GameObject arrow = Instantiate(Arrow,ArrowPoint.transform.forward,Quaternion.identity);
                    arrow.transform.rotation = Quaternion.Euler(90, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
                    arrow.transform.position = ArrowPoint.position;
                    arrow.GetComponent<Rigidbody>().AddForce(ArrowPoint.forward * ArrowSpeed);
                }
    }
}
