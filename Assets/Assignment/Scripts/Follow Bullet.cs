using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBullet : Bullet
{
    protected override void Start()
    {
        base.Start();
        direction = (Player.currentPosition - rb.position).normalized;
        float angle = Mathf.Atan2(direction.x, direction.y)*Mathf.Rad2Deg;
        rb.rotation=-angle;
    }
}
