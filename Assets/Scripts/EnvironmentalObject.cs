using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnvironmentalObject : Destructible
{
    public abstract void OnPlayerCollision(PartyController player);
}
