using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory
{
    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();
    }

    public void AddItem(Item item)
    {
        if(item != null)
        {
            // 아이템 스택 가능 유무
            if (item.isStackable)
            {
                Item finditem = itemList.Find(x => x.UniqueID.Equals(item.UniqueID));
                if (finditem != null)
                {
                    if (typeof(Consumption) == finditem.GetType())
                    {
                        finditem.amount += item.amount;
                    }
                }
                else
                {
                    itemList.Add(item);
                }
            }
            else
            {
                itemList.Add(item);
            }
        }   
    }

    public List<Item> GetItems()
    {
        return itemList;
    }
}
