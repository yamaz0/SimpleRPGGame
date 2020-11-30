using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class AttributesButtonsUI
{
    [SerializeField]
    private Button but1;
    [SerializeField]
    private Button but2;

    public void Init()
    {
        // but1.onClick.AddListener(() => Player.Instance.Attributes.AddAttributeProgress(AttributesScriptableObject.MagicAttributes.KNOWLEDGE,10));
        // but2.onClick.AddListener(() => Player.Instance.Attributes.AddAttributeProgress(AttributesScriptableObject.MagicAttributes.CONCETRATION,10));
    }
}
