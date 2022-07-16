using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    // Start is called before the first frame update
    public enum BiomDice {Meadow,Desert,Volcano,Ocean,DeadLand,Snow,Empty};
    public enum StructureDice {Castle,Forest,Town,Camp,Empty};
    public RollResults RollDice()
    {
        BiomDice biomDice = (BiomDice)Random.Range(0, 6);
        StructureDice structureDice = (StructureDice)Random.Range(0, 5);
        Debug.Log(biomDice+" "+structureDice);
        return new RollResults(biomDice, structureDice);
    }
    public class RollResults
    {
        public BiomDice biomDice;
        public StructureDice structureDice;
        public RollResults(BiomDice biomDice,StructureDice structureDice)
        {
            this.biomDice = biomDice;
            this.structureDice = structureDice;
        }
    }
}
