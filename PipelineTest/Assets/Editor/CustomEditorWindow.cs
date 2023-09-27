using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomEditorWindow : EditorWindow
{
    //create a "CustomWindow" window in editor/tools
    [MenuItem("Tools/CustomWindow")]
    public static void ShowWindow()
    {
        //this custom window is called: Content Loader
        GetWindow<CustomEditorWindow>("ContentLoader");
    }

    //what does our custom window do?
    void OnGUI()
    {
        //add a title that says "Load Excel" in bold
        GUILayout.Label("Load Excel", EditorStyles.boldLabel);
        
        //create a button "Load Excel"
        if (GUILayout.Button("Load Excel"))
        {
            //find the game object and load stuff
            GameObject.Find("ContentDatabase").GetComponent<LoadExcel>().LoadContentData();
            //when the "Load Excel" button is clicked, call this function
            //LoadExcel();
        }
    }

    //we load content from the excel sheet with this function
    void LoadExcel()
    {
        
    }
}
