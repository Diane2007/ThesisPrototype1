using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Content
{
    public int id;
    public string title;
    public string subtitle;
    public string content;

    public Content(Content doc)
    {
        id = doc.id;
        title = doc.title;
        subtitle = doc.subtitle;
        content = doc.content;
    }
}
