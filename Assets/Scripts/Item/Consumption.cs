﻿using System;
using System.Text;
using System.Collections.Generic;
using Project_RPG;

public enum ConsumptionType
{ 
    HP = 0,
    MP = 1,
    STAMINA = 2,
}


public class Consumption : Item
{
    public ConsumptionType consumptionType;
    public int value;

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"<size=30>{itemName}</size>");        
        sb.AppendLine($"<size=15>{GetTypeText()} : {value}</size>");
        sb.AppendLine($"<size=15>Price : {price}</size>");

        return base.ToString();
    }

    private string GetTypeText()
    {
        switch(consumptionType)
        {
            default:
                return "";
            case ConsumptionType.HP:
                return "Hp";
            case ConsumptionType.MP:
                return "Mp";
            case ConsumptionType.STAMINA:
                return "Stamina";
        }
    }
}