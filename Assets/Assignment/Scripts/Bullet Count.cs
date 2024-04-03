using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCount : MonoBehaviour
{
    public static int bulletCount {  get; private set; }
    // Start is called before the first frame update
    public static void AddBulletCount()
    {
        bulletCount++;
    }
}
