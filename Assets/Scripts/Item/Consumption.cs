using System;
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
    public ConsumptionType consumptipnType;
    public int value;    
    
}