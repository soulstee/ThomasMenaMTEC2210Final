using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = -2;
    private AudioSource audioSource;

    public AudioClip explodeClip;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float y = speed * Time.deltaTime;
        transform.Translate(0, y, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Bullet")
        {
            audioSource.PlayOneShot(explodeClip);
            Destroy(gameObject);
        }
    }
}
