using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Singleton<Player>
{
    [SerializeField]
    private Character character;
    [SerializeField]
    private GameInputsController gameInputController;
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
