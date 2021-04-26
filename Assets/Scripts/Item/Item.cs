using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project_RPG;

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


namespace Project_RPG
{   

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

        private ItemBehaviour mItemBehaviour;
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
}



