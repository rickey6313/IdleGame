﻿using System;
using System.Collections.Generic;
using Project_RPG;
using System.Text;

public class Equipment : Item
{
    public int attack;
    public int defence;
    public int evade;
    public int hp;
    public int mp;
    public int stamina;

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"<size=30>{itemName}</size>");
        sb.AppendLine($"<size=15>Damage : {attack}</size>");
        sb.AppendLine($"<size=15>HP : {hp}</size>");
        sb.AppendLine($"<size=15>Price : {price}</size>");

        return base.ToString();
    }
}
