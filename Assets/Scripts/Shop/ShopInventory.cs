using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopInventory : InventoryUI
{
    private InventoryController SellerCharacterInventory { get; set; }
    public bool IsPlayer { get; set; }

    public bool BuyItem(Item item)
    {
        bool hasEnoughMoney = SellerCharacterInventory.Inventory.AddGold(-item.Price);

        if (hasEnoughMoney == false)
        {
            Debug.Log("Not enough money");
            return false;
        }

        CharacterInventory.Inventory.AddGold(item.Price);

        if (IsPlayer == true)
        {
            CharacterInventory.RemoveItem(item);
        }
        else
        {
            SellerCharacterInventory.AddItem(item);
            Refresh();
        }


        return true;
    }

    public void Init(InventoryController seller, InventoryController buyer, bool isPlayer)
    {
        SellerCharacterInventory = seller;
        CharacterInventory = buyer;
        IsPlayer = isPlayer;
    }
    public override void Init()
    {
        ShopItemSlotUIController shopController = new ShopItemSlotUIController();
        shopController.Init(this);
        SetController(shopController);
    }


    // public void Refresh(int nothing = 0)
    // {
    //     ShopItemSlotUIController Controller = new ShopItemSlotUIController();
    //     List<Item> items = CharacterInventory.Inventory.Items;

    //     Controller.Init(this);

    //     if (Objects.Count != 0)
    //     {
    //         for (int i = Objects.Count - 1; i >= 0; i--)
    //         {
    //             Destroy(Objects[i].gameObject);
    //         }
    //         Objects.Clear();
    //     }

    //     foreach (var item in items)
    //     {
    //         Slot slot = GameObject.Instantiate(slotTemplate, content);
    //         slot.Init(item, Controller);
    //         slot.gameObject.SetActive(true);

    //         Objects.Add(slot);
    //     }
    //     goldText.SetTextValue(CharacterInventory.Inventory.Gold.ToString());
    // }
}
