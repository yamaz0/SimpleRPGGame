[System.Serializable]
public class TrainerNPC : NPCBase
{
    public TrainerNPC(NPCInfo info) : base(info)
    {
    }


    public void Load()
    {

    }

    public override void Use()
    {
        PopUpManager.Instance.ShowAbilitiesWindow((TrainerNPCInfo)NpcInfo);
    }
}
