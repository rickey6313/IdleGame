using System;
using System.Text;

public struct ItemPropertyData
{
    public int statsID;
    public string name;
    public float min;
    public float max;

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"statsID : {statsID} / min : {min} / max : {max}");
        return sb.ToString();
    }
}
