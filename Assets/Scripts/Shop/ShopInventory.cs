using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventory : MonoBehaviour
{
    [SerializeField]
    private Character characterCache;
    private List<Slot> objects = new List<Slot>(10);
    public Slot slotTemplate;
    public Transform content;

    public List<Slot> Objects { get => objects; set => objects = value; }

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.I))
    //         Initialize();
    // }

    private void Start()
    {
        Objects = new List<Slot>();
        characterCache.InventoryController.Inventory.OnInventoryChanged += Refresh;
        Refresh();
    }

    private void OnDisable()
    {
        characterCache.InventoryController.Inventory.OnInventoryChanged -= Refresh;
    }

    public void Refresh(int nothing = 0)
    {
        ShopItemSlotUIController ctrl = new ShopItemSlotUIController();
        List<Item> items = characterCache.InventoryController.Inventory.Items;

        if (Objects.Count != 0)
        {
            for (int i = Objects.Count - 1; i >= 0; i--)
            {
                Destroy(Objects[i].gameObject);
            }
            Objects.Clear();
        }

        foreach (var item in items)
        {
            CreateNewSlot(item, ctrl);
        }
    }

    private void CreateNewSlot(Item item, ShopItemSlotUIController controller)
    {
        Slot slot = GameObject.Instantiate(slotTemplate, content);
        slot.Init(item, controller);
        slot.gameObject.SetActive(true);

        Objects.Add(slot);
    }

}
