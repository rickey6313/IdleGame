using System.Collections;
using System.Collections.Generic;

public class ItemPropertyModifier
{
    
    public void CreatePrefix()
    {
        List<Ability> list = new List<Ability>();
        for(int i = 0; i < 3; i++)
        {
            list.Add(ItemPropertyCreator.CreatePrefix());
        }

        foreach(Ability ab in list)
        {
            UnityEngine.Debug.Log(ab.ToString());
        }
    }

}
