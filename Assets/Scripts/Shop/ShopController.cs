using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField]
    private ShopInventory playerInventory;
    [SerializeField]
    private ShopInventory NPCInventory;

private void OnEnable() {
    // playerInventory.Init();
    // NPCInventory.Init();
}
}
