using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    // Start is called before the first frame update
    public MapSO mapSO;
    [SerializeField]
    public GameObject hexagon;
    public GameObject map;
    private void Start()
    {
        GenerateLevel();
    }
    public void GenerateLevel()
    {
        Vector3 objSize = Vector3.Scale(hexagon.transform.localScale, hexagon.GetComponentInChildren<MeshRenderer>().bounds.size);
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                float xPos = i * objSize.x;
                if (j % 2 == 1)
                {
                    xPos += objSize.x / 2f;
                }
                GameObject temp=Instantiate(hexagon, new Vector3(xPos, 0, j * objSize.x - (j * 0.14f)), Quaternion.identity);
                temp.transform.parent = map.transform;
                if (i == 0 && j == 0)
                {
                    temp.GetComponent<WorldMapHexagon>().LoadHex(new DiceRoll.RollResults(DiceRoll.BiomDice.Meadow, DiceRoll.StructureDice.Empty));
                }
                else
                {
                    temp.GetComponent<WorldMapHexagon>().LoadHex(new DiceRoll.RollResults(DiceRoll.BiomDice.Empty, DiceRoll.StructureDice.Empty));
                }
                temp.GetComponent<WorldMapHexagon>().x = i;
                temp.GetComponent<WorldMapHexagon>().y = j;
            }
        }

    }
}
