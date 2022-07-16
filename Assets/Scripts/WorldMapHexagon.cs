using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapHexagon : MonoBehaviour
{
    [SerializeField]
    private GameObject hexagon;
    [SerializeField]
    private GameObject structure;
    public List<GameObject> bioms;
    public List<GameObject> structures;
    public void LoadHex(DiceRoll.RollResults rollResults) {
        hexagon.GetComponent<MeshFilter>().mesh = bioms[(int)rollResults.biomDice].GetComponent<MeshFilter>().sharedMesh;
        switch (rollResults.structureDice)
        {
            case DiceRoll.StructureDice.Forest:
                switch (rollResults.biomDice)
                {
                    case DiceRoll.BiomDice.Desert:
                        structure.GetComponent<MeshFilter>().mesh = structures[1].GetComponent<MeshFilter>().sharedMesh;
                        break;
                    case DiceRoll.BiomDice.DeadLand:
                        structure.GetComponent<MeshFilter>().mesh = structures[4].GetComponent<MeshFilter>().sharedMesh;
                        break;
                    case DiceRoll.BiomDice.Meadow:
                        structure.GetComponent<MeshFilter>().mesh = structures[0].GetComponent<MeshFilter>().sharedMesh;
                        break;
                    case DiceRoll.BiomDice.Ocean:
                        structure.GetComponent<MeshFilter>().mesh = structures[3].GetComponent<MeshFilter>().sharedMesh;
                        break;
                    case DiceRoll.BiomDice.Volcano:
                        structure.GetComponent<MeshFilter>().mesh = structures[2].GetComponent<MeshFilter>().sharedMesh;
                        break;
                    case DiceRoll.BiomDice.Snow:
                        structure.GetComponent<MeshFilter>().mesh = structures[5].GetComponent<MeshFilter>().sharedMesh;
                        break;
                }
                break;
            case DiceRoll.StructureDice.Castle:
                if (rollResults.biomDice != DiceRoll.BiomDice.DeadLand)
                {
                    structure.GetComponent<MeshFilter>().mesh = structures[6].GetComponent<MeshFilter>().sharedMesh;
                }
                else
                    structure.GetComponent<MeshFilter>().mesh = structures[7].GetComponent<MeshFilter>().sharedMesh;
                break;
            case DiceRoll.StructureDice.Camp:
                structure.GetComponent<MeshFilter>().mesh = structures[8].GetComponent<MeshFilter>().sharedMesh;
                break;
            case DiceRoll.StructureDice.Town:
                structure.GetComponent<MeshFilter>().mesh = structures[9].GetComponent<MeshFilter>().sharedMesh;
                break;
            case DiceRoll.StructureDice.Chest:
                structure.GetComponent<MeshFilter>().mesh = structures[10].GetComponent<MeshFilter>().sharedMesh;
                break;
        }
        
    }
}
