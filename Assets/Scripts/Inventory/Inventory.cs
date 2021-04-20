using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project_RPG;

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
            switch (item.itemType)
            {
                case ItemType.Equipment:
                    AddEquipItem(item as Equipment);
                    break;
                case ItemType.Consumption:
                    AddItemConsumption(item as Consumption);
                    break;
            }
        }   
    }

    private void AddEquipItem(Equipment item)
    {   
        itemList.Add(item);        
    }

    private void AddItemConsumption(Consumption item)
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

    public List<Item> GetItems()
    {
        return itemList;
    }
}
