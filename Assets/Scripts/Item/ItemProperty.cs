using System;
using System.Collections.Generic;
public struct ItemProperty
{
    public int statsID;
    public string name;
    public float value;
    

    public override string ToString()
    {   
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append($"statsID : {statsID} / value : {value}");
        return sb.ToString();
    }
}
