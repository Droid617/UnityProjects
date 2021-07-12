using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class DataClick : MonoBehaviour
{   
    private string currData;
    private string answer;
    public GameObject gameManager;
    public GameObject nextBtn;
    public GameObject restartBtn;
    public GameObject restartPanel;
    public GameObject purpose;
    public GameObject star;

    public int lvl = 1;

    public void Start()
    {

    }

    public void OnMouseDown()
    {
        currData = GetComponent<SpriteRenderer>().sprite.name;
        answer = purpose.GetComponent<Text>().text.Substring(5);

        if (currData == answer)
        {
            transform.DOPunchScale(new Vector3(2f, 2f, 0), 2f, 5, 1);
            Instantiate(star, transform.position, Quaternion.identity);
            if (lvl != 2)
            {
                nextBtn.transform.position = new Vector3(9.5f, -3.5f, -2f);
            }
            if(lvl == 2)
            {
                lvl = 1;
                restartBtn.transform.position = new Vector3(0f, 0f, -6f);
                restartPanel.GetComponent<SpriteRenderer>().DOFade(0.4f, 2f);
                gameManager.GetComponent<GameManager>().NotClick();
                purpose.GetComponent<Text>().DOFade(0f, 2f);
            }
        }
        else
        {
            gameObject.transform.DOPunchPosition(new Vector3(transform.position.x, 0.5f, transform.position.z), 2f, 10, 0.4f, false);
        }
    }
}
