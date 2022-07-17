using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPiercing : MonoBehaviour
{
    public int dmg;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            transform.SetParent(other.transform);
            other.GetComponent<Health>().DamageMe(dmg);
            Destroy(GetComponent<Rigidbody>());
            Destroy(gameObject, 15f);
        }
    }
}
