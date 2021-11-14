using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttributesTextUI
{
    [SerializeField]
    private Transform attributesTextContent;
    [SerializeField]
    private AttributeTextController attributeTextPrefab;

public List<AttributeTextController> textControllers;
    public void Init()
    {
        textControllers.Clear();
        List<ProgressAttribute> attributesList = Player.Instance.Character.Attributes.Attributes;

        for (int i = 0; i < attributesList.Count; i++)
        {
            AttributeTextController attributeTextController = GameObject.Instantiate(attributeTextPrefab,attributesTextContent);
            attributeTextController.Initialize(attributesList[i]);
            attributesList[i].OnProgressChange += (x)=>{attributeTextController.SetAtributeProgers(x.ToString());};
            attributeTextController.SetAtributeProgers(attributesList[i].GetProgressPercent().ToString());
            textControllers.Add(attributeTextController);
        }
    }
    public void DetachAll()
    {
        for (int i = textControllers.Count - 1; i >= 0 ; i--)
        {
            textControllers[i].Detach();
            GameObject.Destroy(textControllers[i].gameObject);
        }
    }
}
