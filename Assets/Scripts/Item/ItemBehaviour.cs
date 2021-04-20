using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Project_RPG;


public class ItemBehaviour : MonoBehaviour
{
    private Item mItem;

    [SerializeField] 
    private Image mItemImage;
    [SerializeField] 
    private TextMeshProUGUI mAmountText;
    [SerializeField]
    private GameObject mTooltip;

    private void Start()
    {
        
    }

    public void SetItem(Item item)
    {
        mItem = item;
    }

    public void ShowToolTip()
    {
        Debug.Log("1");
        mTooltip.SetActive(true);
    }

    public void HideToolTipe()
    {
        Debug.Log("2");
        mTooltip.SetActive(false);
    }
    public void Test1()
    {
        Debug.Log("3");
    }
    public void Test2()
    {
        Debug.Log("4");
    }
    public void Test3()
    {
        Debug.Log("5");
    }

}

