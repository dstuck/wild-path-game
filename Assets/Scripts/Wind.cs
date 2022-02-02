using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : EnvironmentalObject
{
    private float rotation;
    public override void OnPlayerCollision(PartyController player)
    {
        player.ModifyDirection(-20.0f);
    }
}
