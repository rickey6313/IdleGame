using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    private bool isPlayerNear = false;
    
    // Start is called before the first frame update
    void Start()
    {
        isPlayerNear = false;
    }

    private void Update()
    {
        if(isPlayerNear)
        {
            if (Input.GetKeyUp(KeyCode.I))
            {
                UIManager.Instance.SwitchInventoryUI();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            isPlayerNear = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = false;
    }
}
