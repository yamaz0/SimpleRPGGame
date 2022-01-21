using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityIcon : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image icon;
    [SerializeField]
    private UnityEngine.UI.Text durationText;
    [SerializeField]
    private UnityEngine.UI.Text exhaustText;
    public void Init(Ability ability)
    {
        icon.sprite = ability.AbilityInfo.Icon;
        ability.OnStateChanged += ChangeSpriteEffect;
        ability.DurationTimer.OnTimeChanged += ChangeDurationNumberText;
        ability.ExhaustTimer.OnTimeChanged += ChangeExhaustNumberText;
        ChangeDurationNumberText(ability.DurationTimer.DurationTurnTime);
        ChangeExhaustNumberText(ability.ExhaustTimer.DurationTurnTime);
    }
    private void ChangeDurationNumberText(int value)
    {
        durationText.text = value.ToString();
    }

    private void ChangeExhaustNumberText(int value)
    {
        exhaustText.text = value.ToString();
    }

    private void ChangeSpriteEffect(AbilityState state)
    {
        switch (state)
        {
            case AbilityState.Ready:
                icon.color = new Color(1, 1, 1, 1);
                durationText.gameObject.SetActive(false);
                exhaustText.gameObject.SetActive(false);
                break;
            case AbilityState.InUse:
                icon.color = new Color(1, 1, 1, 0.5f);
                durationText.gameObject.SetActive(true);
                exhaustText.gameObject.SetActive(false);
                break;
            case AbilityState.Exhaust:
                icon.color = new Color(0, 0, 0, 0.8f);
                durationText.gameObject.SetActive(false);
                exhaustText.gameObject.SetActive(true);
                break;
            default:
                Debug.LogError("AbilityState not exist!");
                break;
        }
    }
}
