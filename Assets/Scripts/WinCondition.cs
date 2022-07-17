using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public GameObject map;
    public void AwaitWin()
    {
        StartCoroutine(AwaitWinCorountine());
    }
    IEnumerator AwaitWinCorountine()
    {
        for(; PlayerPrefs.GetInt("Win")==1;)
        {
            Debug.Log("sss");
            yield return new WaitForSeconds(0.01f);
        }
        SceneManager.UnloadSceneAsync("Forest"); 
        map.SetActive(true);
        map.GetComponentInChildren<MapPlayer>().CheckHex();
    }
}
