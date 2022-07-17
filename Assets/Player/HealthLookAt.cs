using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthLookAt : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("MainCamera").transform);
    }
}
