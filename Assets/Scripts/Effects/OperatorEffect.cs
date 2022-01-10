using UnityEngine;

[System.Serializable]
public class OperatorEffect
{
    [SerializeField]
    private bool xd;
    public virtual float Calc(Character character){return -1;}
}