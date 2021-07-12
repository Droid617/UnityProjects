using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NextController : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject dataObj;

    void Start()
    {

    }

    public void OnMouseDown()
    {
        gameManager.GetComponent<GameManager>().CellUp();
        gameManager.GetComponent<GameManager>().LoadLevel();
        dataObj.GetComponent<DataClick>().lvl++;
        transform.position = new Vector3(15f, -3.5f, -2f);
    }
}
