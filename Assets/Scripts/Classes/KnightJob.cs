using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KnightJob : JobBase
{
    //public RangerJob(GameObject _player) : base(_player) { }
    public override float GetSpeed()
    {
        return 1.6f;
    }

    public override float GetTurnSpeed()
    {
        return 0.8f;
    }

    public override void SetSprite(GameObject player)
    {
        getSpriteRenderer(player);
        spriteRenderer.material.color = Color.blue;
    }
}
