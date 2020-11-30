using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesUI : MonoBehaviour
{
    public bool isVisible = false;
    [SerializeField]
    private AttributesButtonsUI attributesButtonsUI;
    [SerializeField]
    private AttributesTextUI attributesTextUI;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(isVisible == false)
            {
                attributesTextUI.Init();
                attributesButtonsUI.Init();
            }
            else
            {
                attributesTextUI.DetachAll();
            }

            isVisible = !isVisible;
        }

    }


}
