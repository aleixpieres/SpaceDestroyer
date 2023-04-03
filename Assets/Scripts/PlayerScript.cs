using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Rigidbody2D player;

    public float rotationSpeed;
    public float bulletCooldown;
    public float PowerUpCooldown;

    public AudioSource shootSound;

    bool canShoot;
    bool canDoubleShot;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        canShoot = true;
        canDoubleShot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) & canShoot)
        {
            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            diff = diff.normalized;
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            if (!canDoubleShot)
            {
                var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
                shootSound.Play();
            }
            else {
                Vector3 doublepos1 = new Vector3(0.5f, 0f,0f);
                Vector3 doublepos2 = new Vector3(-0.5f, 0f, 0f);
                var bullet1 = Instantiate(bulletPrefab, transform.position + doublepos1, transform.rotation) as GameObject;
                var bullet2 = Instantiate(bulletPrefab, transform.position + doublepos2, transform.rotation) as GameObject;
                shootSound.Play();
                shootSound.Play();
            }
            canShoot = false;
            StartCoroutine("CoolDown");
        }
    }

    IEnumerator CoolDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(bulletCooldown);
            canShoot = true;
        }

    }
    IEnumerator PowerUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(PowerUpCooldown);
            canShoot = true;
        }

    }

    public void doubleShot() 
    {
        print("double");
        canDoubleShot = true;
        StartCoroutine("CoolDown");
    }
}
