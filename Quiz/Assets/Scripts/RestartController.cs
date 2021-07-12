using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class RestartController : MonoBehaviour
{
    public GameObject restartPnl;
    public GameObject gmManager;

    public void OnMouseDown()
    {
        restartPnl.GetComponent<SpriteRenderer>().DOFade(1f, 4f);
        gmManager.GetComponent<GameManager>().ClearData();
        gmManager.GetComponent<GameManager>().ClearCell();
        gmManager.GetComponent<GameManager>().RestartLvl();
        transform.position = new Vector3(0f, 0f, 6f);
        restartPnl.GetComponent<SpriteRenderer>().DOFade(0f, 6f);
        LoadingRestart();
        gmManager.GetComponent<GameManager>().LoadLevel();
    }

    IEnumerator LoadingRestart()
    {
        yield return new WaitForSeconds(20);
    }
}
