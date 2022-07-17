using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapHexagon : MonoBehaviour
{
    [SerializeField]
    private GameObject hexagon;
    [SerializeField]
    private GameObject structure;
    public int x, y;
    public DiceRoll.RollResults rollResults;
    public void LoadHex(DiceRoll.RollResults rollResults)
    {
        this.rollResults = rollResults;
        MapSO mapSO = GameObject.Find("MapInfo").GetComponent<MapGeneration>().mapSO;
        if(rollResults.biomDice==DiceRoll.BiomDice.Empty) hexagon.GetComponent<MeshFilter>().mesh = mapSO.biomes[6].GetComponent<MeshFilter>().sharedMesh;
        else
        hexagon.GetComponent<MeshFilter>().mesh = mapSO.biomes[(int)rollResults.biomDice].GetComponent<MeshFilter>().sharedMesh;
        switch (rollResults.structureDice)
        {
            case DiceRoll.StructureDice.Forest:
                switch (rollResults.biomDice)
                {
                    case DiceRoll.BiomDice.Desert:
                        structure.GetComponent<MeshFilter>().mesh = mapSO.structures[1].GetComponent<MeshFilter>().sharedMesh;
                        break;
                    case DiceRoll.BiomDice.DeadLand:
                        structure.GetComponent<MeshFilter>().mesh = mapSO.structures[4].GetComponent<MeshFilter>().sharedMesh;
                        break;
                    case DiceRoll.BiomDice.Meadow:
                        structure.GetComponent<MeshFilter>().mesh = mapSO.structures[0].GetComponent<MeshFilter>().sharedMesh;
                        break;
                    case DiceRoll.BiomDice.Ocean:
                        structure.GetComponent<MeshFilter>().mesh = mapSO.structures[3].GetComponent<MeshFilter>().sharedMesh;
                        break;
                    case DiceRoll.BiomDice.Volcano:
                        structure.GetComponent<MeshFilter>().mesh = mapSO.structures[2].GetComponent<MeshFilter>().sharedMesh;
                        break;
                    case DiceRoll.BiomDice.Snow:
                        structure.GetComponent<MeshFilter>().mesh = mapSO.structures[5].GetComponent<MeshFilter>().sharedMesh;
                        break;
                }
                break;
            case DiceRoll.StructureDice.Castle:
                if (rollResults.biomDice != DiceRoll.BiomDice.DeadLand)
                {
                    structure.GetComponent<MeshFilter>().mesh = mapSO.structures[6].GetComponent<MeshFilter>().sharedMesh;
                }
                else
                    structure.GetComponent<MeshFilter>().mesh = mapSO.structures[7].GetComponent<MeshFilter>().sharedMesh;
                break;
            case DiceRoll.StructureDice.Camp:
                structure.GetComponent<MeshFilter>().mesh = mapSO.structures[9].GetComponent<MeshFilter>().sharedMesh;
                break;
            case DiceRoll.StructureDice.Town:
                structure.GetComponent<MeshFilter>().mesh = mapSO.structures[8].GetComponent<MeshFilter>().sharedMesh;
                break;
            case DiceRoll.StructureDice.Empty:
                structure.GetComponent<MeshFilter>().mesh = null;
                break;
        }
        gameObject.GetComponent<Animator>().Play("HexAnim");
    }
}
