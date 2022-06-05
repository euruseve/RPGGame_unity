using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public static int pchar = 0;
    public static string pname = "player";

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    /*void Update()
    {
        
    }
    */
}
