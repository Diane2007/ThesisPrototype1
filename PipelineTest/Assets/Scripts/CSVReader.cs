using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using System.Text.RegularExpressions;

public class CSVReader
{
    //absolutely no clue what these symbols are but let's try
    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
    static char TRIM_CHARS = '\"';
        
    //parse the excel-turned-csv doc
    public static List<Dictionary<string, object>> Read(string file)
    {
        //define contentList as a list of dictionaries that contain a string and another
        //for the title and content
        var contentList = new List<Dictionary<string, object>>();
        
        //load data from the csv file uploaded
        TextAsset excel = Resources.Load(file) as TextAsset;

        //slice the document into columns using the symbols
        string[] lineList = Regex.Split(excel.text, LINE_SPLIT_RE);

        //if there is only one id number, just return that id
        if (lineList.Length <= 1)
        {
            return contentList;
        }

        //get those id numbers
        string[] header = Regex.Split(lineList[0], SPLIT_RE);
        
        //loop through the columns, starting with 1 because we have the header as the first value and we don't want that
        for (int i = 1; i < lineList.Length; i++)
        {
            //get each line's values
            string[] lineValue = Regex.Split(lineList[i], SPLIT_RE);
            
            //if that line only has empty values, skip it and continue running the code
            if (lineValue.Length == 0 || lineValue[0] == "")
            {
                continue;
            }

            //define that each line content has two strings
            Dictionary<string, object> entry = new Dictionary<string, object>();
            for (int a = 0; a < header.Length && a < lineValue.Length; a++)
            {
                string value = lineValue[a];
                //trim out the \\
                value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                object secondValue = value;
                int n;
                float f;
                if (int.TryParse(value, out n))
                {
                    secondValue = n;
                }

                if (float.TryParse(value, out f))
                {
                    secondValue = f;
                }
                entry[header[a]] = secondValue;
            }
            contentList.Add(entry);

        }

        return contentList;
    }
}
