using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : Singleton<PopUpManager>
{
    [SerializeField]
    private PopUpControllerUI popUpController;

    public void ShowEndBattlePopUp(string title, string desc)
    {
        popUpController.ShowEndBattlePopUp(title, desc);
    }
}
