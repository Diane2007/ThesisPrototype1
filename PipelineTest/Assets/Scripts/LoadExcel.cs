using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoadExcel : MonoBehaviour
{
    public Content blankContent;
    public List<Content> contentDatabase = new List<Content>();

    public void LoadContentData()
    {
        //start with a clean sheet
        contentDatabase.Clear();
        
        //read CSV file
        List<Dictionary<string, object>> docContent = CSVReader.Read("NewspaperMockUp");
        for (int i = 0; i < docContent.Count; i++)
        {
            int id = int.Parse(docContent[i]["id"].ToString(), System.Globalization.NumberStyles.Integer);
            string title = docContent[i]["title"].ToString();
            string subtitle = docContent[i]["subtitle"].ToString();
            string content = docContent[i]["content"].ToString();

            AddItem(id, title, subtitle, content);
        }
    }

    public void GetDocContent()
    {
        
    }

    void AddItem(int id, string title, string subtitle, string content)
    {
        Content tempContent = new Content(blankContent);

        tempContent.id = id;
        tempContent.title = title;
        tempContent.subtitle = subtitle;
        tempContent.content = content;
        
        contentDatabase.Add(tempContent);
    }
}