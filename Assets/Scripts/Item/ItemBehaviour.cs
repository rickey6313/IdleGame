﻿using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemBehaviour : MonoBehaviour
{
    private Item mItem;

    [SerializeField] 
    private Image mItemImage;
    [SerializeField]
    private TextMeshProUGUI mAmountText;
    [SerializeField]
    private ItemTooltipBehaviour mTooltip;

    private void Start()
    {
        Init();
    }

    private void Init()
    {   
        mTooltip.SetDescripton(mItem.ToString());
        mTooltip.gameObject.SetActive(false);
    }

    public void SetItem(Item item)
    {
        mItem = item;
    }

    public void ShowToolTip()
    {
        mTooltip.gameObject.SetActive(true);
    }

    public void HideToolTipe()
    {
        mTooltip.gameObject.SetActive(false);
    }
}

