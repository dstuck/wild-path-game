using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest : EnvironmentalObject
{
    private float rotation;
    public override void OnPlayerCollision(PartyController player)
    {
        rotation = Random.Range(10.0f, 45.0f);
        if (Random.value > 0.5)
        {
            rotation = -rotation;
        }
        player.ModifyDirection(rotation);
    }
}
