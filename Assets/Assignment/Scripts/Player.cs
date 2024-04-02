using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public static Vector2 currentPosition;

    Rigidbody2D rb;
    Vector2 direction;

    public float speed=1f;
    public GameObject bulletPrefab;
    public float shootingInterval=1f;

    float cooldownInterval=0;
    
    Coroutine shooting;
    bool isShooting = false;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
        currentPosition = rb.position;
    }
    private void Update()
    {
        cooldownInterval += Time.deltaTime;
        //avoid continously press space to speed up the shooting
        if (Input.GetKeyDown(KeyCode.Space) && cooldownInterval>shootingInterval)
        {   
            if(shooting!=null)StopCoroutine(shooting); 
            shooting=StartCoroutine(SpawnBullet());  
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isShooting = false;
        }
    }
    IEnumerator SpawnBullet()
    {
        isShooting = true;
        cooldownInterval = 0;
        while (isShooting){
            Instantiate(bulletPrefab,transform.position,transform.rotation);
            yield return new WaitForSeconds(shootingInterval);
        }
    }
}
