using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : EnemyBullet
{
    public Transform[] spawnPoints;
    protected override IEnumerator Shoot()
    {
        while (true)
        {
            foreach (Transform point in spawnPoints)
            {
                Instantiate(bulletPrefab, point.position, point.rotation);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
