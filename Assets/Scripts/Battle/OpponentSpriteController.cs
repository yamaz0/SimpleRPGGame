using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentSpriteController : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer leftHandSprite;
    [SerializeField]
    private SpriteRenderer rightHandSprite;
    [SerializeField]
    private SpriteRenderer helmetSprite;
    [SerializeField]
    private SpriteRenderer armorSprite;
    [SerializeField]
    private SpriteRenderer legsSprite;
    [SerializeField]
    private SpriteRenderer bootsSprite;


    public void SetSprites(Character character)
    {
        foreach (Equipement.EqType t in (Equipement.EqType[])System.Enum.GetValues(typeof(Equipement.EqType)))
        {
            Item item = character.InventoryController.GetItemByType(t);
            if (item != null)
                SetItemSprite(t, item.Icon);
        }
    }

    private void SetItemSprite(Equipement.EqType equipType, Sprite sprite)
    {
        switch (equipType)
        {
            case Equipement.EqType.Helmet:
                helmetSprite.sprite = sprite;
                break;
            case Equipement.EqType.Armor:
                armorSprite.sprite = sprite;
                break;
            case Equipement.EqType.Legs:
                legsSprite.sprite = sprite;
                break;
            case Equipement.EqType.Boots:
                bootsSprite.sprite = sprite;
                break;
            case Equipement.EqType.HandLeft:
                leftHandSprite.sprite = sprite;
                break;
            case Equipement.EqType.HandRight:
                rightHandSprite.sprite = sprite;
                break;
            default:
                Debug.LogError("ErrorType");
                return;
        }
    }
}
