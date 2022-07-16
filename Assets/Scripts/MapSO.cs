using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="MapSO",menuName ="SO/MapSO",order =1 )]
public class MapSO : ScriptableObject
{
    public List<GameObject> biomes;
    public List<GameObject> structures;
}
