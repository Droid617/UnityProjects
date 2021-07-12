using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    List<string> nameCheck = new List<string>();//Add elemName from spriteCheck (to check  is there future textName or not**)
    List<Sprite> spriteCheck;//for non doubleAppearing sprite(reverse **)
    List<GameObject> forClearData = new List<GameObject>();
    List<GameObject> forClearCell = new List<GameObject>();
    public int levelNum = 0;
    
    public GameObject cell;
    public GameObject dataObject;
    public Text textPurpose;
    public Color txtColor;

    public List<GameObject> spriteObjects;
    public List<Sprite> needRotate;

    public int count = 0;

    public void Start()
    {
        CellUp();
        LoadLevel();
    }

    public void Update()
    {
        //unityEvent by click, if click next -> loadlevel(next)
    }

    public void LoadLevel()//only add (not reload old), istantiate new
    {
        if(forClearData.Count > 0)
        {
            ClearData();
        }
        GameObject obj = spriteObjects[Random.Range(0, spriteObjects.Count)];
        spriteCheck = new List<Sprite>(obj.GetComponent<TypeOfSprites>().sprites);

        int cycleCount = 1;
        int j = 2;
        if (levelNum == 6) { j = 0; cycleCount = 2; }
        if (levelNum == 9) { j = -2; cycleCount = 3; }
        for (int i = -2; i < 4; i += 2)
        {
            GameObject cloneCell = Instantiate(cell, new Vector3(i, j, 0), Quaternion.identity);
            cloneCell.transform.DOPunchScale(new Vector3(2f, 2f, 0), 2f, 5, 1);
            forClearCell.Add(cloneCell);
        }

        StartCoroutine(DataLoading());

        j = 2;
        while (cycleCount != 0)
        {
            for (int i = -2; i < 4; i += 2)
            {
                int idx = Random.Range(0, spriteCheck.Count);//spriteCheck[idx]
                GameObject cloneData = Instantiate(dataObject, new Vector3(i, j, -0.01f), Quaternion.identity);
                forClearData.Add(cloneData);//.....................
                count++;
                cloneData.GetComponent<SpriteRenderer>().sprite = spriteCheck[idx];
                nameCheck.Add(spriteCheck[idx].name);

                for (int k = 0; k < needRotate.Count; k++)
                {
                    if (needRotate[k] == spriteCheck[idx])
                    {
                        cloneData.transform.eulerAngles = new Vector3(0, 0, -90);
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

                cloneData.transform.DOPunchScale(new Vector3(2f, 2f, 0), 2f, 5, 1);
                spriteCheck.RemoveAt(idx);
            }
            cycleCount--;
            j -= 2;
        }

        int index = Random.Range(0, nameCheck.Count);
        textPurpose.text = "Find " + nameCheck[index];
        textPurpose.DOColor(txtColor, 5.0f);

        nameCheck.Clear();
        //
        //random sprite
        //instantiate sprites(cell and data)dopunchscale and text dofade
    }

    IEnumerator DataLoading()
    {
        yield return new WaitForSeconds(3);
    }

    public void CellUp()
    {
        levelNum += 3;
    }

    public void NotClick()
    {
        for (int i = 0; i < forClearData.Count; i++)
        {
            if (forClearData[i] != null) 
            {
                forClearData[i].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    public void ClearData() 
    {
        for(int i = 0;i < forClearData.Count; i++)
        {
            Destroy(forClearData[i].gameObject);
        }
    }

    public void ClearCell()
    {
        for (int i = 0; i < forClearCell.Count; i++)
        {
            if (forClearCell[i] != null)
            {
                Destroy(forClearCell[i].gameObject);
            }
        }
    }

    public void RestartLvl()
    {
        levelNum = 3;
        count = 0;
    }
}
