using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public GameObject powerUpPrefab;
    public Rigidbody2D Rigidbody2D;
    private Vector3 target;
    public AudioSource deadSound;
    public AudioSource explosionSound;

    public float health;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
       target = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {   
        Rigidbody2D.position = Vector2.MoveTowards(Rigidbody2D.position, target, speed*Time.deltaTime);
    }

    public void takeDamage() 
    {
        //explosionSound.Play();
        health -= 5.0f;
        transform.localScale = transform.localScale / 2;
        if (health == 0)
        {
            int powerUp = Random.Range(0, 10);
            if (powerUp == 0) 
            {
                var powerUpvar= Instantiate(powerUpPrefab, transform.position, transform.rotation) as GameObject;
            }
            Destroy(gameObject);
        } 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //deadSound.Play();
            Destroy(collision.gameObject);
            Destroy(gameObject);
            SceneManager.LoadScene("SampleScene");
        }
    }
}
