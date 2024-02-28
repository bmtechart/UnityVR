using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuManager : MonoBehaviour
{

    public GameObject pausemenu;

    public InputActionProperty Showmenu;

    public Transform head;

    public float spawnDistance = 2;




    void Start()
    {
        
    }

   
    void Update()
    {
        if (Showmenu.action.WasPressedThisFrame())
        {
            pausemenu.SetActive(!pausemenu.activeSelf);

            pausemenu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance; 
        }

        pausemenu.transform.LookAt(new Vector3 (head.position.x, pausemenu.transform.position.y, head.position.z));

        //pausemenu.transform.forward *= -1;
    }
}
