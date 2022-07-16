using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public int damage;
    public Type type;
    public string Prefab;
    public Vector3 rot;
    public Vector3 pos;
    public bool _isRHand;
}

public enum Type
{
    melee,
    ranged
}