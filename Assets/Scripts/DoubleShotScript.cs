using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShotScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Bullet")
        {
            PlayerScript playerScript = player.gameObject.GetComponent(typeof(PlayerScript)) as PlayerScript;
            if (player != null) 
            {
                playerScript.doubleShot();
                Destroy(gameObject);
            }
        }
    }
 
}
