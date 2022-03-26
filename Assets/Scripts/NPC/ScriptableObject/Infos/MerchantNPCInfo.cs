using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MerchantNPCInfo : NPCInfo
{
    [SerializeField]
    private List<ItemId> itemsIds;
    [SerializeField]
    private int gold;

    public List<ItemId> ItemsIds { get => itemsIds; set => itemsIds = value; }
    public int Gold { get => gold; set => gold = value; }

    public override NPCBase CreateNpc()
    {
        return new MerchantNPC(this);
    }

    [System.Serializable]
    public class ItemId
    {
        [SerializeField]
        [IdDropdown(typeof(ItemsScriptableObject))]
        private int id;

        public int ID { get => id; set => id = value; }
    }
}
