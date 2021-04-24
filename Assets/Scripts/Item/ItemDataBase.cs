using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase
{
    private static ItemDataBase _instance = null;
    public static ItemDataBase instance
    {
        get 
        { 
            if (_instance == null)
            {
                _instance = new ItemDataBase();
            }
            return _instance;
        }
    }
    private static List<Dictionary<string, object>> csvPotionData;
    private static List<Dictionary<string, object>> csvEquipmentData;

    public static List<Dictionary<string, object>> PotionData
    {
        get { return csvPotionData; }
    }
    public static List<Dictionary<string, object>> EquipmentData
    {
        get { return csvEquipmentData; }
    }

    private static List<Consumption> expandableItem;

    public static void ReadItemData()
    {
        csvPotionData = CSVReader.Read("PotionDB");
        csvEquipmentData = CSVReader.Read("EquipmentDB");
    }    
}
