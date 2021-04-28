using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    public static GameInstance Instance;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
        ItemDataBase.ReadItemData();
        ItemPropertyDataBase.ReadItemPropertiesData();
        ItemFactory.DataParseToClass();
        ItemPropertyCreator.DataParseToClass();
    }
}