using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject boat;
    public GameObject sail;
    public GameObject paddle;
    public float range = 2f;

    void Update()
    {
        if (Input.GetButtonDown("Action"))
        {
            Interact();
        }

        if (Input.GetButtonDown("Inventory"))
        {
            SetInventoryVisible(!InventoryUI.instance.gameObject.activeSelf);
        }
    }

    public void SetInventoryVisible(bool value)
    {
        InventoryUI.instance.gameObject.SetActive(value);
        GameManager.instance.input.gameObject.SetActive(value);
        GetComponent<FirstPersonController>().enabled = !value;
        Cursor.lockState = value ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = value ? Cursor.visible = true : Cursor.visible = false;
    }

    void Interact()
    {
        Ray r = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        int ignorePlayer = ~LayerMask.GetMask("Player");

        if (Physics.Raycast(r, out hit, range, ignorePlayer))
        {
            //Debug.Log("Hit " + hit.collider.gameObject.name);
            IInteractable i = hit.collider.gameObject.GetComponent<IInteractable>();
            if (i != null)
            {
                i.Action();
            }
        }

        //if (hit.collider.gameObject.tag == "Escape")
        //{
            if (paddle && sail && boat.activeInHierarchy == false)
            {
                // StartCoroutine(TypeText.instance.ShowDialogText("You have found al the parts you escaped the prison enjoy your freedom!"));
                StartCoroutine(ExitGame());
            }
        
        }
    //}
    public IEnumerator ExitGame()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1);
    }
}