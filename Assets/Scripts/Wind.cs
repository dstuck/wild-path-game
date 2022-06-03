using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : EnvironmentalObject
{
    public float maxRotation = 20.0f;
    public float BlowAngle { get => blowAngle; set => onBlowAngleSet(value); }

    private float blowAngle = 0.0f;
    private Vector2 blowDirection = new Vector2(1.0f, 0.0f);

    private void Start()
    {
        BlowAngle = -45.0f;
    }

    private void onBlowAngleSet(float newAngle)
    {
        float delta = newAngle - blowAngle;
        transform.Rotate(new Vector3(0.0f, 0.0f, delta));
    }

    public override void OnPlayerCollision(PartyController player)
    {
        //Quaternion fullRotation = Quaternion.FromToRotation(player.transform.up, transform.right);
        float fullRotation = Vector2.SignedAngle(player.transform.up, transform.right);

        player.ModifyDirection(
            Mathf.Max(Mathf.Min(fullRotation, maxRotation), -maxRotation)
        );
    }
}
