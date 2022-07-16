using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hex;
    void Start()
    {
        
    }
    public void Reroll()
    {
        hex.GetComponent<WorldMapHexagon>().LoadHex(transform.GetComponent<DiceRoll>().RollDice());
    }
}
