using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrainerNPCInfo : NPCInfo
{
    [SerializeField]
    private List<AbilityId> abilitiesIds;

    public List<AbilityId> AbilitiesIds { get => abilitiesIds; set => abilitiesIds = value; }

    public override NPCBase CreateNpc()
    {
        return new TrainerNPC(this);
    }

    [System.Serializable]
    public class AbilityId
    {
        [SerializeField]
        [IdDropdown(typeof(AbilityScriptableObject))]
        private int id;
        [SerializeField]
        private int cost;

        public int ID { get => id; set => id = value; }
        public int Cost { get => cost; set => cost = value; }
    }
}
