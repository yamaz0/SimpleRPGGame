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
    private float speed;
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
        // Inventory = new Inventory();
        Character.Initialize();
        // gameInputController.Player.Move.started += Move;
        gameInputController.Player.Move.performed += Move;
    }

    private void OnEnable()
    {
        gameInputController.Enable();
    }

    private void OnDisable()
    {
        gameInputController.Player.Move.performed -= Move;
        gameInputController.Disable();
    }

    public void KnowledgeAdd()
    {
        // Attributes.AddAttributeProgress(AttributesScriptableObject.MagicAttributes.KNOWLEDGE, 10);
    }

    public void ConcetrationAdd()
    {
        // Attributes.AddAttributeProgress(AttributesScriptableObject.MagicAttributes.CONCETRATION, 10);
    }
    private void Move(InputAction.CallbackContext context)
    {
        Debug.Log("move");
        Vector2 movementValues = context.ReadValue<Vector2>();
        gameObject.transform.Translate(movementValues * Time.deltaTime * speed);
    }

    protected override void Initialize()
    {
        base.Initialize();
        gameInputController = new GameInputsController();
    }
}
