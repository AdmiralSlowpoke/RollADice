using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadForest : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> trees;
    public List<Material> materials;
    public List<GameObject> ocean;
    public MeshRenderer mesh;
    void Start()
    {
        int biome = PlayerPrefs.GetInt("Biome");
        GenerateLand((DiceRoll.BiomDice)biome);
        GenerateForest((DiceRoll.BiomDice)biome);
    }
    public void GenerateLand(DiceRoll.BiomDice biom)
    {
        switch (biom)
        {
            case DiceRoll.BiomDice.Desert:
                mesh.material = materials[3];
                break;
            case DiceRoll.BiomDice.DeadLand:
                mesh.material = materials[0];
                break;
            case DiceRoll.BiomDice.Meadow:
                mesh.material = materials[1];
                break;
            case DiceRoll.BiomDice.Ocean:
                mesh.material = materials[3];
                ocean[0].SetActive(true);
                ocean[1].SetActive(true);
                break;
            case DiceRoll.BiomDice.Snow:
                mesh.material = materials[4];
                break;
            case DiceRoll.BiomDice.Volcano:
                mesh.material = materials[5];
                break;
        }
    }
    public void GenerateForest(DiceRoll.BiomDice biom)
    {
        for(int i = 0; i < trees.Count; i++)
        {
            if (Random.Range(0, 11) > 6)
            {
                trees[i].SetActive(false);
            }
            else
                trees[i].GetComponent<RandomTree>().LoadTree(biom);
        }
    }
}
