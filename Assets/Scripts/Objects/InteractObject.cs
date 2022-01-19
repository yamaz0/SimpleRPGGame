using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface IInteractable
{
    void Use();
}
public class InteractObject : MonoBehaviour, IInteractable
{
    [SerializeReference]
    private List<OneCharacterEffect> efects;
    [SerializeField]
    private GameInputsController gameInputController;
    [SerializeField]
    private GameObject useUI;
    bool isActive = false;
    public List<OneCharacterEffect> Efects { get => efects; set => efects = value; }

    private void Awake()
    {
        gameInputController = new GameInputsController();
    }

    private void OnEnable()
    {
        gameInputController.Enable();
    }

    private void OnDisable()
    {
        gameInputController.Disable();
    }

    public void Use()
    {
        Character character = Player.Instance.Character;
        Efects.ForEach(x => x.Execute(character));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameInputController.Player.Interact.started += _ => Use();
            useUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameInputController.Player.Interact.started -= _ => Use();
            useUI.SetActive(false);
        }
    }
}

[UnityEditor.CustomEditor(typeof(InteractObject))]
public class InteractObjectEditor : UnityEditor.Editor
{
    List<System.Type> types;
    bool showPosition;
    public InteractObjectEditor()
    {
        types = System.Reflection.Assembly.GetAssembly(typeof(OneCharacterEffect)).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(OneCharacterEffect))).ToList();
    }
    public override void OnInspectorGUI()
    {
        var script = (InteractObject)target;
        showPosition = UnityEditor.EditorGUILayout.Foldout(showPosition, "Add effects buttons");
        if (showPosition)
        {
            foreach (var t in types)
            {
                if (GUILayout.Button($"{t.ToString()}", GUILayout.Height(40)))
                {
                    OneCharacterEffect e = System.Activator.CreateInstance(t) as OneCharacterEffect;
                    e.Name = t.ToString();
                    script.Efects.Add(e);
                }
            }
        }
        base.OnInspectorGUI();
    }
}