using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JobBase
{
    //protected GameObject player;
    protected SpriteRenderer spriteRenderer;

    //public JobBase(GameObject _player)
    //{
    //    player = _player;
    //}

    public void getSpriteRenderer(GameObject player)
    {
        spriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    public abstract float GetSpeed();
    public abstract float GetTurnSpeed();
    public abstract void SetSprite(GameObject player);
}
