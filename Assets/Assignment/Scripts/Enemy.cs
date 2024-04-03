using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    Vector2 targetPos;
    Vector2 move;
    static float health = 100;
    public Slider healthBar;

    public GameObject followBulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Movement());
        healthBar.value=healthBar.maxValue=health; 
    }

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
            BulletCount.AddBulletCount();
            yield return new WaitForSeconds(3);
        }
    }

    void takeDamage(float damage)
    {
        health -= damage;
        healthBar.value = health;
        if (health <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    




}
