using System;
using System.Collections.Generic;

public static class ItemPropertyCreator
{
    private static Dictionary<int, ItemPropertyData> mPrefixDict = new Dictionary<int, ItemPropertyData>();
    private static Dictionary<int, ItemPropertyData> mSurrfxDict = new Dictionary<int, ItemPropertyData>();
    private static Random random = new Random();

    public static ItemProperty CreatePrefix()
    {   
        int uniqueID = random.Next(0, mPrefixDict.Count);
        ItemProperty property = new ItemProperty();
        ItemPropertyData data = mPrefixDict[uniqueID];
        property.statsID = data.statsID;
        property.name = data.name;
        property.value = random.Next((int)data.min, (int)data.max);
        
        return property;
    }

    public static ItemPropertyData CreatePrefix(int uniqueID)
    {
        return mPrefixDict[uniqueID];
    }

    public static ItemProperty CreateSurffix()
    {
        int uniqueID = random.Next(0, mSurrfxDict.Count);
        ItemProperty property = new ItemProperty();
        ItemPropertyData data = mSurrfxDict[uniqueID];
        property.statsID = data.statsID;
        property.value = random.Next((int)data.min, (int)data.max);

        return property;
    }

    public static ItemPropertyData CreateSurffix(int uniqueID)
    {
        return mSurrfxDict[uniqueID];
    }

    public static void DataParseToClass()
    {
        DataParseToExpandableItem(mPrefixDict);
        DataParseToExpandableItem(mSurrfxDict, false);
    }

    private static void DataParseToExpandableItem(Dictionary<int, ItemPropertyData> dict, bool isPrefix = true)
    {
        List<Dictionary<string, object>> csvData = new List<Dictionary<string, object>>();
        if (isPrefix)
        {
            csvData = ItemPropertyDataBase.PrefixData;
        }
        else
        {
            csvData = ItemPropertyDataBase.SuffixData;
        }
         
        for (int i = 0; i < csvData.Count; i++)
        {
            ItemPropertyData data;
            data.statsID = int.Parse(csvData[i]["StatsID"].ToString());
            data.name =  csvData[i]["Name"].ToString();
            data.min = int.Parse(csvData[i]["Min"].ToString());
            data.max = int.Parse(csvData[i]["Max"].ToString());
            dict.Add(i, data);
        }
    }
}

