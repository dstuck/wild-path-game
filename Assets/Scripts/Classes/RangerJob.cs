using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RangerJob : JobBase
{
    //public RangerJob(GameObject _player) : base(_player) { }
    public override float GetSpeed()
    {
        return 1.0f;
    }

    public override float GetTurnSpeed()
    {
        return 1.5f;
    }

    public override void SetSprite(GameObject player)
    {
        getSpriteRenderer(player);
        spriteRenderer.material.color = Color.green;
    }
}
