using System.Collections;
using System.Collections.Generic;

public static class ItemPropertyModifier
{
    
    public static void CreatePrefix(Item targetItem)
    {
        for(int i = 0; i <3; i++)
        {
            targetItem.itemPropertyList.Add(ItemPropertyCreator.CreatePrefix());
        }
    }

}
