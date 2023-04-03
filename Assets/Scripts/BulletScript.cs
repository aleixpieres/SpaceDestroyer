using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;

    public float delay = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D.transform.Translate(Vector2.up * 20f * Time.deltaTime);
        Destroy(gameObject, delay);
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") 
        {
            EnemyScript enemy = collision.gameObject.GetComponent(typeof(EnemyScript)) as EnemyScript;
            if (enemy != null) enemy.takeDamage();
            Destroy(gameObject);
        }
    }
}
