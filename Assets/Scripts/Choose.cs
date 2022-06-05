using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Choose : MonoBehaviour
{
    public GameObject[] characters;
    public Text playerName;
    private int p = 0;

    void Start()
    {
        
    }

    public void Next()
    {
        if(p < characters.Length - 1)
        {
            characters[p].SetActive(false);
            p++;
            characters[p].SetActive(true);
        }
        
    }

    public void Back()
    {
        if(p > 0)
        {
            characters[p].SetActive(false);
            p--;
            characters[p].SetActive(true);
        }
    }

    public void Accept()
    {
        SaveScript.pchar = p;
        SaveScript.pname = playerName.text;
        SceneManager.LoadScene(1);
    }
}
