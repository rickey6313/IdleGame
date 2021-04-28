using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipment,
    Consumption,
    Goods,
    Etc
}

public enum ItemGrade
{ 
    Normal,
    Magic,
    Rare
}

public class Item
{
    public ItemGrade itemGrade;
    public ItemType itemType;
    public string itemName;
    public string resourcePath;
    public string UniqueID;
    public int amount;
    public bool isStackable;

    public int price;

    public List<ItemProperty> itemPropertyList = new List<ItemProperty>();

    private ItemBehaviour mItemBehaviour;

    protected virtual string ItemPropertiesText()
    {
        StringBuilder sb = new StringBuilder();        
        for (int i = 0; i < itemPropertyList.Count; i++)
        {
            sb.AppendLine($"<size=15>{itemPropertyList[i].name} : {(int)itemPropertyList[i].value}</size>");
        }

        return sb.ToString();

    }

    public ItemBehaviour ItemBehaviour
    {
        get { return mItemBehaviour; }
        set
        {                
            mItemBehaviour = value;
            ItemBehaviour.SetItem(this);
        }
    }
}




