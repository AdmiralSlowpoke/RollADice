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
        for(int i = 0; i < 1000; i++)
        {
            yield return new WaitForSeconds(0.01f);
        }
        SceneManager.UnloadSceneAsync("Forest"); 
        map.SetActive(true);
        map.GetComponentInChildren<MapPlayer>().CheckHex();
    }
}
