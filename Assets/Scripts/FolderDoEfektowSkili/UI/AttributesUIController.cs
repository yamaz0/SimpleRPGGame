using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesUIController : MonoBehaviour
{
    [SerializeField]
    private List<AttributeUIController> attributeUIObjects;

    public List<AttributeUIController> AttributeUIObjects { get => attributeUIObjects; private set => attributeUIObjects = value; }

    private void Start()
    {
        AttributeUIObjects.ForEach(x => x.Init());
    }

    private void OnEnable()
    {
        AttributeUIObjects.ForEach(x => x.AttachedEvents());
    }

    private void OnDisable()
    {
        AttributeUIObjects.ForEach(x => x.DetachEvents());
    }
}
