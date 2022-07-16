using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    // Start is called before the first frame update
    private enum BiomDice {Meadow,Desert,Volcano,Ocean,DeadLand,Snow};
    private enum StructureDice {Castle,Forest,Town,Camp,Empty,Chest};
    void Start()
    {
        RollDice();
    }
    public void RollDice()
    {
        BiomDice biomDice = (BiomDice)Random.Range(0, 6);
        StructureDice structureDice = (StructureDice)Random.Range(0, 6);
        Debug.Log($"{biomDice} {structureDice}");
    }
}
