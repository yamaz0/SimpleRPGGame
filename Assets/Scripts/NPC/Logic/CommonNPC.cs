using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonNPC : NPCBase
{
    public CommonNPC(NPCInfo info) : base(info)
    {
    }


    public override void Use()
    {
        List<string> texts = ((CommonNPCInfo)NpcInfo).Texts;
        int randomId = Random.Range(0, texts.Count);
        string textToSay = texts[randomId];
        //tutaj jakieś uiTextChmurka.show(textToSay);
    }
}
