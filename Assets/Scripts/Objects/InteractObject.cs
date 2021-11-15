using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUseable
{
    void Use();
}
public class InteractObject : MonoBehaviour, IUseable
{
    [SerializeField]
    private AttributesScriptableObject.MagicAttributes atribute;
    [SerializeField]
    private int value;
    [SerializeField]
    private GameObject useUI;
    bool isActive = false;

    private void Update() {
        if(isActive && Input.GetKeyDown(KeyCode.E))
        {
            Use();
        }
    }

    public void Use()
    {
        // Player.Instance.Character.AddProgress(atribute, value);
        // Player.Instance.Character.Attributes.AddAttributeLevel(atribute, value);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            isActive = true;
            useUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            isActive = false;
            useUI.SetActive(false);
        }
    }
}
