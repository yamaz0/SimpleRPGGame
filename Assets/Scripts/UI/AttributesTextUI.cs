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

    public void Init()
    {
        // List<Attribute> attributesList = Player.Instance.Attributes.AttributesList;
        // for (int i = 0; i < attributesList.Count; i++)
        // {
        //     AttributeTextController attributeTextController = GameObject.Instantiate(attributeTextPrefab,attributesTextContent);
        //     attributeTextController.Initialize(attributesList[i]);
        // }
    }

}
