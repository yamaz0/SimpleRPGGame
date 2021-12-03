using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesUIController : MonoBehaviour
{
    [SerializeField]
    List<AttributeUIController> attributes;

    private void Start() {
        attributes.ForEach(x=>x.Init());
    }
}
