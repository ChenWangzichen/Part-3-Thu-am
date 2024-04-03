using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffusionBullet : EnemyBullet
{
    protected override IEnumerator Shoot()
    {
        while (true)
        {
            Vector3 point = new Vector3(Random.Range(-5, 5), Random.Range(0, 6), 0);
            Instantiate(bulletPrefab, point, Quaternion.identity);
            BulletCount.AddBulletCount();
            yield return new WaitForSeconds(Random.Range(1, 10));
        }
    }
}
