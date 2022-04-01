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

    System.Action<UnityEngine.InputSystem.InputAction.CallbackContext> useDelegate;

    private void Awake()
    {
        gameInputController = new GameInputsController();
        useDelegate = delegate (UnityEngine.InputSystem.InputAction.CallbackContext x) { Use(); };
    }

    private void OnEnable()
    {
        gameInputController.Enable();
    }

    private void OnDisable()
    {
        gameInputController.Disable();
    }

    public virtual void Use()
    {
        Character character = Player.Instance.Character;
        for (int i = 0; i < Efects.Count; i++)
        {
            Efects[i].Execute(character);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameInputController.Player.Interact.started += useDelegate;
            useUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameInputController.Player.Interact.started -= useDelegate;
            useUI.SetActive(false);
        }
    }
}
#if UNITY_EDITOR

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
#endif