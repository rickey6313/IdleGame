using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Project_RPG;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;

    [SerializeField]
    private Transform itemSlotTemplate;
    [SerializeField]
    private List<Transform> itemSlotList = new List<Transform>();

    public void SetInventory(Inventory _inventory)
    {
        inventory = _inventory;

        RefreshInventoryItems();

    }

    private void RefreshInventoryItems()
    {
        int index = 0;
        foreach(Item item in inventory.GetItems())
        {
            if (index >= itemSlotList.Count) return;

            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotList[index]).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            ItemBehaviour behaviour = itemSlotRectTransform.GetComponent<ItemBehaviour>();
            item.ItemBehaviour = behaviour;

            Image icon = itemSlotRectTransform.Find("icon").GetComponent<Image>();
            TextMeshProUGUI tmp = itemSlotRectTransform.Find("amount").GetComponent<TextMeshProUGUI>();
            icon.sprite = Resources.Load<Sprite>(item.resourcePath);
            tmp.text = item.amount <= 1 ? "" : item.amount.ToString();
            index++;
        }
    }
}