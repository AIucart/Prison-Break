using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionTest : MonoBehaviour
{
    public string[] names;

    // Start is called before the first frame update
    void Start()
    {
        names = new string[2];
        names[0] = "David";
        names[1] = "David";

        //showNames();

        for (int i = 0; i < names.Length; i++)
        {
            Debug.Log(names[1]);
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown( buttonName: "Fire"))
        {
            AddName("Sofia");
        }
    }
    void AddName(string value)
    {
        string[] newNames;
        newNames = new string[names.Length + 1];
        for (int i = 0; i < names.Length; i++)
        {
            newNames[i] = names[i];
        }
        newNames[newNames.Length - 1] = value;

        names = newNames;
    }
}
