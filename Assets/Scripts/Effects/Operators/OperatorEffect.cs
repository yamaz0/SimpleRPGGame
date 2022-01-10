using UnityEngine;

[System.Serializable]
public class OperatorEffect
{
    public virtual float Calc(Character character){return -1;}
    public virtual void ViewInfo(){}
    public virtual void ViewFields(){}
}