using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    private void Start()
    {
        StartCoroutine(Shoot());
    }
    protected virtual IEnumerator Shoot()
    {
        yield return null;
    }

}
