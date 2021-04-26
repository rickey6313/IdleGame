using System;
using System.Collections.Generic;

public class ItemPropertyDataBase
{
    private static ItemPropertyDataBase _instance = null;
    public static ItemPropertyDataBase instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ItemPropertyDataBase();
            }
            return _instance;
        }
    }
    private static List<Dictionary<string, object>> csvItemPrefixPropertyData;
    public static List<Dictionary<string, object>> PrefixData
    {
        get { return csvItemPrefixPropertyData; }
    }
    private static List<Dictionary<string, object>> csvItemSurffixPropertyData;
    public static List<Dictionary<string, object>> SuffixData
    {
        get { return csvItemSurffixPropertyData; }
    }

    private static List<Consumption> expandableItem;

    public static void ReadItemPropertiesData()
    {
        csvItemPrefixPropertyData = CSVReader.Read("ItemPrefixPropertyDB");
        csvItemSurffixPropertyData = CSVReader.Read("ItemSuffixPropertyDB");
    }
}
