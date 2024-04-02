using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    Vector2 targetPos;
    Vector2 move;

    public GameObject followBulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Movement());
    }

    private void FixedUpdate()
    {
        
        
    }
    private void Update()
    {
        
    }

    // Update is called once per frame

    IEnumerator Movement()
    {
        while (true) { 
            targetPos = new Vector2(Random.Range(-5f, 5f), 4f);
            move = targetPos - rb.position;
            while (move.magnitude > 0.1)
            {
                rb.MovePosition(rb.position + move.normalized * speed * Time.deltaTime);
                yield return null;
                move = targetPos - rb.position;
            }
            //move = Vector2.zero;
            Instantiate(followBulletPrefab,transform.position,transform.rotation);
            yield return new WaitForSeconds(3);
        }
    }

}
