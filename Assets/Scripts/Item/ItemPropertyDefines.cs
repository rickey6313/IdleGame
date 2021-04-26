using System;
using System.Text;

public struct Ability
{
    public int statsID;
    public float min;
    public float max;

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"statsID : {statsID} / min : {min} / max : {max}");
        return sb.ToString();
    }
}