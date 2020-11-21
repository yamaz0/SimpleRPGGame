using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesUI : MonoBehaviour
{
    [SerializeField]
    private AttributesButtonsUI attributesButtonsUI;
    [SerializeField]
    private AttributesTextUI attributesTextUI;

    private void Start()
    {
        attributesTextUI.Init();
    }


}
