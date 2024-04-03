using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Rigidbody2D rb;
    public float speed;
    protected Vector2 direction;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        direction = transform.up;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        fire(direction);
    }

    protected virtual void fire(Vector2 dir)
    {
        rb.MovePosition(rb.position + dir * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("takeDamage", 1, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
    public void setDirection(Vector2 dir)
    {
        direction = dir;
    }
}
