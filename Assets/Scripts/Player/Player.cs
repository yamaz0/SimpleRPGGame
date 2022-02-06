using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class PlayerQuestController
{
    [SerializeField]
    private List<int> doneSideQuestsId = new List<int>();
    [SerializeField]
    private List<int> actualSideQuestsId = new List<int>();
    [SerializeField]
    private int actualMainQuestId;

    public List<int> DoneSideQuestsId { get => doneSideQuestsId; private set => doneSideQuestsId = value; }
    public List<int> ActualSideQuestsId { get => actualSideQuestsId; private set => actualSideQuestsId = value; }
    public int ActualMainQuestId { get => actualMainQuestId; private set => actualMainQuestId = value; }

    public event System.Action<int> OnActualMainQuestIdChanged;
    public event System.Action<int> OnActualSideQuestsIdChanged;
    public event System.Action<int> OnDoneSideQuestsIdChanged;

    public void UpdateActualSideQuest(int sideQuestId)
    {
        ActualSideQuestsId.Remove(sideQuestId);
        OnActualSideQuestsIdChanged(sideQuestId);
        AddDoneSideQuestsId(sideQuestId);
    }

    public void UpdateMainQuestId(int questId)
    {
        ActualMainQuestId = questId;
        OnActualMainQuestIdChanged(questId);
    }

    public void AddActualSideQuestsId(int questId)
    {
        ActualSideQuestsId.Add(questId);
        OnActualSideQuestsIdChanged(questId);
    }

    public void AddDoneSideQuestsId(int questId)
    {
        DoneSideQuestsId.Add(questId);
        OnDoneSideQuestsIdChanged(questId);
    }
    public bool HasDoneSideQuest(int sideQuestId)
    {
        return DoneSideQuestsId.Contains(sideQuestId);
    }
    public bool HasStartedSideQuest(int sideQuestId)
    {
        return ActualSideQuestsId.Contains(sideQuestId);
    }
}

public class Player : Singleton<Player>
{
    [SerializeField]
    private Character character;
    [SerializeField]
    private GameInputsController gameInputController;
    [SerializeField]
    private PlayerQuestController playerQuestController;
    [SerializeField]
    private float speed = 5;
    public Character Character { get => character; set => character = value; }


    public void LoadData()
    {
        SavePlayer.PlayerDeserialize(this);
    }

    public void SaveData()
    {
        SavePlayer.PlayerSerialize(this);
    }

    private void Start()
    {
        // LoadData();
        Character.Initialize();
    }

    private void OnEnable()
    {
        gameInputController.Enable();
    }

    private void OnDisable()
    {
        gameInputController.Disable();
    }

    private void Move()
    {
        Vector2 movementValues = gameInputController.Player.Move.ReadValue<Vector2>();
        gameObject.transform.Translate(movementValues * Time.deltaTime * speed);
    }

    private void Update()
    {
        Move();
    }

    protected override void Initialize()
    {
        base.Initialize();
        gameInputController = new GameInputsController();
    }
}
