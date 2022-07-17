using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MapPlayer : MonoBehaviour
{
    public Transform snap1, snap2;
    private List<Collider> colliders = new List<Collider>();
    public Image biomeImage, structureImage;
    public Text biomeText, structureText;
    public List<Sprite> biomSprites;
    public List<Sprite> structureSprites;
    public GameObject cubeImage;
    public AudioClip diceRollSound;
    public List<AudioClip>textAppearSound;
    public AudioSource audioSource;
    public GameObject map;
    private DiceRoll diceRoll;
    private void Start()
    {
        diceRoll = GameObject.Find("MapInfo").GetComponent<DiceRoll>();
        CheckHex();
    }
    public void CheckHex()
    {
        StartCoroutine(NewTurn());
    }
    private void LoadHex(Transform transform,DiceRoll.RollResults results)
    {
        Collider[] colliders=Physics.OverlapSphere(transform.position, 0.05f);
        this.colliders.AddRange(colliders);
        foreach(Collider col in colliders)
        {
            if (col.name == "Hex")
            {
                col.transform.parent.GetComponent<WorldMapHexagon>().LoadHex(results);
            }
        }
    }
    public IEnumerator NewTurn()
    {
        cubeImage.SetActive(true);
        colliders.Clear();
        audioSource.PlayOneShot(diceRollSound);
        yield return StartCoroutine(CubeRoll(snap1));
        yield return new WaitForSeconds(1f);
        audioSource.PlayOneShot(diceRollSound);
        yield return StartCoroutine(CubeRoll(snap2));
        yield return new WaitForSeconds(1f);
        cubeImage.SetActive(false);
    }
    public IEnumerator CubeRoll(Transform transform)
    {
        biomeText.gameObject.SetActive(false);
        structureText.gameObject.SetActive(false);
        DiceRoll.RollResults rollResults = diceRoll.RollDice();
        for(int i = 0; i < Random.Range(6, 11); i++)
        {
            biomeImage.sprite = biomSprites[Random.Range(0, biomSprites.Count)];
            yield return new WaitForSeconds(0.05f * i);
        }
        biomeImage.sprite = biomSprites[(int)rollResults.biomDice];
        biomeText.text = rollResults.biomDice.ToString();
        audioSource.PlayOneShot(textAppearSound[Random.Range(0,textAppearSound.Count)]);
        biomeText.gameObject.SetActive(true);
        biomeText.gameObject.GetComponent<Animator>().Play("TextAnim");
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < Random.Range(6, 11); i++)
        {
            structureImage.sprite = structureSprites[Random.Range(0, structureSprites.Count)];
            yield return new WaitForSeconds(0.05f * i);
        }
        structureImage.sprite = structureSprites[(int)rollResults.structureDice];
        structureText.text = rollResults.structureDice.ToString();
        audioSource.PlayOneShot(textAppearSound[Random.Range(0, textAppearSound.Count)]);
        structureText.gameObject.SetActive(true);
        structureText.gameObject.GetComponent<Animator>().Play("TextAnim");
        yield return new WaitForSeconds(0.5f);
        LoadHex(transform, rollResults);

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.GetComponentInParent<WorldMapHexagon>())
                {
                    for(int i = 0; i < colliders.Count; i++)
                    {
                        if (colliders[i] == hit.collider)
                        {
                            PlayerPrefs.SetInt("Biome", (int)hit.transform.GetComponentInParent<WorldMapHexagon>().rollResults.biomDice);
                            transform.position = colliders[i].transform.position+new Vector3(0,transform.position.y,0);
                            if (hit.transform.GetComponentInParent<WorldMapHexagon>().rollResults.structureDice == DiceRoll.StructureDice.Forest)
                                SceneManager.LoadScene("Forest", LoadSceneMode.Additive);
                            colliders.Clear();
                            break;
                        } 
                    }
                    if (SceneManager.sceneCount > 1)
                    {
                        FindObjectOfType<WinCondition>().AwaitWin();
                        map.SetActive(false);
                    }
                    else
                    {
                        CheckHex();
                    }
                }
            }
        }
    }
}
