using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BookItemsScriptableObject", menuName = "ScriptableObjects/BookItemsScriptableObject")]
public class BookItemsScriptableObject : ItemsScriptableObject<BookItemsScriptableObject, BookItemsScriptableObject.BookItemInfo>
{

    [System.Serializable]
    public class BookItemInfo: ItemInfo
    {
        [SerializeField]
        private int bookXp;

        public int BookXp { get => bookXp; set => bookXp = value; }
    }
}
