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
        WindowManager.Instance.ShowAbilitiesWindow((TrainerNPCInfo)NpcInfo);
    }
}
