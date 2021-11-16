using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ShowItemsEditorWindow : EditorWindow
{
    Vector2 scrollPos;
    public void ShowItems()
    {
        List<ItemsScriptableObject.ItemInfo> items = ItemsScriptableObject.Instance.Items;

        if (items != null)
        {
            scrollPos = GUILayout.BeginScrollView(scrollPos,false,true);
            GUILayout.BeginVertical();

            int w = 0;
            int h = 0;

            items.ForEach(x =>
            {
                if(w == 0)
                {
                    GUILayout.BeginHorizontal();
                }
                GUILayout.BeginVertical();

                    GUILayout.BeginArea(new Rect(100*w, 100*h, 200, 200));
                GUILayout.Label("Id: " + x.Id.ToString());
                GUILayout.Label("Name: " + x.ItemName);
                GUILayout.Label("Type: " + x.ItemType.ToString());
                GUILayout.Space(10);
                    GUILayout.EndArea();

                GUILayout.EndVertical();

                w++;
                if(w > Screen.width/100-1)
                {
                    w = 0;
                    h++;
                    GUILayout.EndHorizontal();
                }
            });


            GUILayout.EndVertical();
            GUILayout.EndScrollView();
        }
    }
}
