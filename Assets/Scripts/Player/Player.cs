using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    [SerializeField]
    private Character character;
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
    }

    public void KnowledgeAdd()
    {
        // Attributes.AddAttributeProgress(AttributesScriptableObject.MagicAttributes.KNOWLEDGE, 10);
    }

    public void ConcetrationAdd()
    {
        // Attributes.AddAttributeProgress(AttributesScriptableObject.MagicAttributes.CONCETRATION, 10);
    }
    private void Update() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        gameObject.transform.Translate(new Vector2(h, v) * Time.deltaTime * speed);
    }
}
