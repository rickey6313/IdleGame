using System;
using System.Collections.Generic;


public static class ItemFactory
{
    private static List<Consumption> mExpandableItemList;
    private static List<Equipment> mEquipmentItemList;

    public static Equipment SpawnEquipment(string uniqueID)
    {
        return mEquipmentItemList.Find(x => x.UniqueID.Equals(uniqueID));
        
    }

    public static Consumption SpawnConsumption(string uniqueID)
    {
        return mExpandableItemList.Find(x => x.UniqueID.Equals(uniqueID));
    }

    public static void DataParseToClass()
    {
        DataParseToExpandableItem();
        DataParseToEquipmentItem();
    }

    private static void DataParseToExpandableItem()
    {
        mExpandableItemList = new List<Consumption>();
        List<Dictionary<string, object>> csvPotionData = ItemDataBase.PotionData;
        for (int i = 0; i < csvPotionData.Count; i++)
        {
            Consumption potion = new Consumption();
            potion.UniqueID = csvPotionData[i]["UniqueID"].ToString();
            potion.itemType = ItemType.Consumption;
            potion.itemName = csvPotionData[i]["Name"].ToString();
            potion.resourcePath = csvPotionData[i]["ResourcePath"].ToString();
            potion.amount = int.Parse(csvPotionData[i]["Amount"].ToString());
            potion.price = int.Parse(csvPotionData[i]["Price"].ToString());
            bool b;
            potion.isStackable = bool.TryParse(csvPotionData[i]["isStackable"].ToString(), out b);

            potion.consumptionType = (ConsumptionType)int.Parse(csvPotionData[i]["ConsumptionType"].ToString());
            potion.value = int.Parse(csvPotionData[i]["Value"].ToString());
            mExpandableItemList.Add(potion);
        }
    }
    private static void DataParseToEquipmentItem()
    {
        mEquipmentItemList = new List<Equipment>();
        List<Dictionary<string, object>> csvPotionData = ItemDataBase.EquipmentData;
        for (int i = 0; i < csvPotionData.Count; i++)
        {
            Equipment equipment = new Equipment();
            equipment.UniqueID = csvPotionData[i]["UniqueID"].ToString();
            equipment.itemType = ItemType.Equipment;
            equipment.itemName = csvPotionData[i]["Name"].ToString();
            equipment.resourcePath = csvPotionData[i]["ResourcePath"].ToString();
            equipment.price = int.Parse(csvPotionData[i]["Price"].ToString());
            equipment.attack = int.Parse(csvPotionData[i]["Attack"].ToString());
            equipment.defence = int.Parse(csvPotionData[i]["Defence"].ToString());
            equipment.evade = int.Parse(csvPotionData[i]["Evade"].ToString());
            equipment.hp = int.Parse(csvPotionData[i]["Hp"].ToString());
            equipment.mp = int.Parse(csvPotionData[i]["Mana"].ToString());
            equipment.stamina = int.Parse(csvPotionData[i]["Stamina"].ToString());
            mEquipmentItemList.Add(equipment);
        }
    }
}

