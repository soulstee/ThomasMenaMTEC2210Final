using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public Projectile bulletPrefab;
    public float speed = 7.0f;

    private AudioSource audioSource;

    public AudioClip bulletClip;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");

        float xMovement = xMove * speed * Time.deltaTime;

        transform.Translate(xMovement, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Z)) 
        {
            Shoot();
            audioSource.PlayOneShot(bulletClip);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Shoot()
    {
        Instantiate(this.bulletPrefab, this.transform.position, Quaternion.identity); 
    }
}
