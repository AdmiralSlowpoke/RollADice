using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTree : MonoBehaviour
{
    public List<GameObject> insideTrees;
    public void Start()
    {
        for(int i=0;i<insideTrees.Count;i++)
        {
            insideTrees[i].SetActive(false);
        }
    }
    public void LoadTree(DiceRoll.BiomDice biom)
    {
        switch (biom) {
            case DiceRoll.BiomDice.Meadow:
                insideTrees[Random.Range(0, 3)].SetActive(true);
                break;
            case DiceRoll.BiomDice.Ocean:
                insideTrees[8].SetActive(true);
                break;
            case DiceRoll.BiomDice.Snow:
                insideTrees[Random.Range(3, 6)].SetActive(true);
                break;
            default:
                insideTrees[Random.Range(6, 8)].SetActive(true);
                break;
        }
    }
}
