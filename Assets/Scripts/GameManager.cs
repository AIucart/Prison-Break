using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public string desc;
    public int totalRaftParts = 0;
    public GameObject key;
    public InputField input;
    public GameObject door;

    private void Awake()
    {
        instance = this;  
    }

    // Update is called once per frame
   private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(input.text == desc)
            {
                door.GetComponent<Door>().open = true;
            }
        }
    }
}
