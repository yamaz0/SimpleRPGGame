using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestItemsScriptableObject", menuName = "ScriptableObjects/QuestItemsScriptableObject")]
public class QuestItemsScriptableObject : ItemsScriptableObject<QuestItemsScriptableObject, QuestItemsScriptableObject.QuestItemInfo>
{

    [System.Serializable]
    public class QuestItemInfo: ItemInfo
    {
        [SerializeField]
        private int questId;

        public int QuestId { get => questId; set => questId = value; }
    }
}
