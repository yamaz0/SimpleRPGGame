using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttributesTextUI
{
    [SerializeField]
    private TMPro.TMP_Text knowledgeText;
    [SerializeField]
    private TMPro.TMP_Text ConcetrationText;

    public void Init()
    {
        Player.Instance.Attributes.Knowledge.OnProgressChange += SetKnowledgeText;
        Player.Instance.Attributes.Concetration.OnProgressChange += SetConcetrationText;
    }

    public void SetKnowledgeText(float value)
    {
        knowledgeText.text = value.ToString();
    }

    public void SetConcetrationText(float value)
    {
        ConcetrationText.text = value.ToString();
    }
}
