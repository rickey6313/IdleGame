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
        //ItemDataBase.DataParseToExpandableItem();
        ItemFactory.DataParseToClass();
    }
    // Start is called before the first frame update
    void Start()
    {
        //UIManager.Instance.SetActiveInventoryPanel(false);
    }
}