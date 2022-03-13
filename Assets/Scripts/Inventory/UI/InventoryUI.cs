using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InventoryUI : MonoBehaviour
{
    private List<Slot> objects = new List<Slot>(10);
    public Slot slotTemplate;
    public Transform content;
    public TextValueUI goldText;
    protected IItemSlotUIController Controller { get; set; }
    protected InventoryController CharacterInventory { get; set; }

    public List<Slot> Objects { get => objects; set => objects = value; }

    private void Awake()
    {
        Init();
        Objects = new List<Slot>();

    }

    public virtual void Init()
    {
        CharacterInventory = Player.Instance.Character.InventoryController;
        SetController(new InventoryItemSlotUIController());
    }

    public void SetController(IItemSlotUIController controller)
    {
        Controller = controller;
    }
    private void OnEnable()
    {
        Refresh();
        goldText.Init("gold", CharacterInventory.Inventory.Gold.ToString());
        CharacterInventory.Inventory.OnInventoryChanged += Refresh;
        CharacterInventory.Inventory.OnGoldValueChanged += RefreshGold;
    }
    private void OnDisable()
    {
        CharacterInventory.Inventory.OnInventoryChanged -= Refresh;
        CharacterInventory.Inventory.OnGoldValueChanged -= RefreshGold;
    }

    public void Refresh(int nothing = 0)
    {
        Inventory inventory = CharacterInventory.Inventory;
        List<Item> items = inventory.Items;

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
            CreateNewSlot(item, Controller);
        }
    }

    public void RefreshGold(int gold)
    {
        goldText.SetTextValue(gold.ToString());
    }

    private void CreateNewSlot(Item item, IItemSlotUIController controller)
    {
        Slot slot = GameObject.Instantiate(slotTemplate, content);
        slot.Init(item, controller);
        slot.gameObject.SetActive(true);

        Objects.Add(slot);
    }

}