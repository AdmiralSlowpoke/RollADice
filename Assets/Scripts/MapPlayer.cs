using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayer : MonoBehaviour
{
    public Transform snap1, snap2;
    public void CheckHex()
    {
        LoadHex(snap1);
        LoadHex(snap2);
    }
    private void LoadHex(Transform transform)
    {
        Collider[] colliders=Physics.OverlapSphere(transform.position, 0.05f);
        foreach(Collider col in colliders)
        {
            if (col.name == "Hex")
            {
                col.transform.parent.GetComponent<WorldMapHexagon>().LoadHex(GameObject.Find("MapInfo").GetComponent<DiceRoll>().RollDice());
            }
        }
    }
}
