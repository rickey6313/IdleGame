using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVReader
{
    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
    static char[] TRIM_CHARS = { '\"' };

    public static List<Dictionary<string, object>> Read(string file)
    {
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
#if UNITY_EDITOR || UNITY_STANDALONE
        string dir = Application.dataPath + "/StreamingAssets/" + file + ".csv";
        if(!File.Exists(dir))
        {
            Debug.LogError(file + "������ �������� �ʽ��ϴ�");
            return list;
        }
        string source;
        StreamReader sr = new StreamReader(dir);
        source = sr.ReadToEnd();
        sr.Close();
        string[] lines = Regex.Split(source, LINE_SPLIT_RE);
#else
        TextAsset data = Resources.Load(file) as TextAsset;
        string[] lines = Regex.Split(data.text, LINE_SPLIT_RE);
#endif
        if (lines.Length <= 1) return list;

        string[] header = Regex.Split(lines[0], SPLIT_RE);
        for(var i =1; i < lines.Length; i++)
        {
            string[] values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "") continue;
            Dictionary<string, object> entry = new Dictionary<string, object>();
            for(var j = 0; j< header.Length && j < values.Length; j++)
            {
                string value = values[j];
                value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                object finalvalue = value;
                int n;
                float f;
                bool b;
                short s;
                if (int.TryParse(value, out n))
                {
                    finalvalue = n;
                }
                else if(float.TryParse(value, out f))
                {
                    finalvalue = f;
                }
                else if(bool.TryParse(value, out b))
                {
                    finalvalue = b;
                }
                else if(short.TryParse(value, out s))
                {
                    finalvalue = s;
                }
                entry[header[j]] = finalvalue;
            }
            list.Add(entry);
        }
        return list;
    }
}
