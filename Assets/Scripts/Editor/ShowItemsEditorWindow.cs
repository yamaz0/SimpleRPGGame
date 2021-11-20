using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ShowItemsEditorWindow : EditorWindow
{
    Vector2 scrollPos;
    public void ShowItems(CreateItemsEditorWindow createItemsEditorWindow, test t)
    {
        List<ItemInfo> items = ItemsScriptableObject.Instance.Items;

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
                                    GUILayout.Box(x.Icon.texture);
                                    // GUI.DrawTexture(new Rect(0,0,50,50),x.Icon.texture);
                                        // GUILayout.BeginHorizontal();
                                        if(GUILayout.Button("Modify"))
                                        {
                                            createItemsEditorWindow.SetValuesFields(x.Id, x.ItemName, x.Icon);
                                            t.CurrentState = test.State.MODIFY;
                                        }
                                        // GUILayout.EndHorizontal();
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
