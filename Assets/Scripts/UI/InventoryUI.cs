using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
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
        Player.Instance.Character.InventoryController.Inventory.OnInventoryChanged += Refresh;
        Refresh(0);
    }
    private void OnDisable()
    {
        Player.Instance.Character.InventoryController.Inventory.OnInventoryChanged -= Refresh;
    }

    public void Refresh(int zmiennaDoUsuniecia)
    {
        if (Objects.Count != 0)
        {
            for (int i = Objects.Count - 1; i >= 0; i--)
            {
                Destroy(Objects[i].gameObject);
            }
            Objects.Clear();
        }
        List<int> itemsIds = Player.Instance.Character.InventoryController.Inventory.ItemsId;

        for (int i = 0; i < itemsIds.Count; i++)
        {
            CreateNewSlot(itemsIds[i]);
        }
    }

    private void CreateNewSlot(int id)
    {
        Item item = CreateItem(id);

        Slot slot = GameObject.Instantiate(slotTemplate, content);
        slot.Init(item);
        slot.gameObject.SetActive(true);

        Objects.Add(slot);
    }

    private Item CreateItem(int id)
    {
        // ItemsManager itemsManager = ItemsManager.Instance;
        ItemInfo itemInfo = ItemsScriptableObject.Instance.GetItemInfoById(id);
        return itemInfo.CreateItem();
    }
}
