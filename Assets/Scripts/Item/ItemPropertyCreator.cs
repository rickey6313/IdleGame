using System;
using System.Collections.Generic;

public static class ItemPropertyCreator
{
    private static Dictionary<int, Ability> mPrefixDict = new Dictionary<int, Ability>();
    private static Dictionary<int, Ability> mSurrfxDict = new Dictionary<int, Ability>();


    public static Ability CreatePrefix()
    {
        Random random = new Random(DateTime.Now.Millisecond);        
        int uniqueID = random.Next(0, mPrefixDict.Count);
        return mPrefixDict[uniqueID];
    }

    public static Ability CreatePrefix(int uniqueID)
    {
        return mPrefixDict[uniqueID];
    }

    public static Ability CreateSurffix()
    {
        Random random = new Random(DateTime.Now.Millisecond);
        int uniqueID = random.Next(0, mSurrfxDict.Count); ;
        return mSurrfxDict[uniqueID];
    }

    public static Ability CreateSurffix(int uniqueID)
    {
        return mSurrfxDict[uniqueID];
    }

    public static void DataParseToClass()
    {
        DataParseToExpandableItem(mPrefixDict);
        DataParseToExpandableItem(mSurrfxDict, false);
    }

    private static void DataParseToExpandableItem(Dictionary<int, Ability> dict, bool isPrefix = true)
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
            Ability ablitiy = new Ability();
            ablitiy.statsID = int.Parse(csvData[i]["StatsID"].ToString());            
            ablitiy.min = int.Parse(csvData[i]["Min"].ToString());
            ablitiy.max = int.Parse(csvData[i]["Max"].ToString());
            dict.Add(i, ablitiy);
        }
    }
}

