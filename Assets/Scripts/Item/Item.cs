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

namespace Project_RPG
{   

    public class Item
    {
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



