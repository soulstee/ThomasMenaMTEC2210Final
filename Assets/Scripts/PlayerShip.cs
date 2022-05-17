using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShip : MonoBehaviour
{
    public Projectile laserPrefab;
    public float speed = 6.0f;

    private bool _laserActive;

    private void Update() // this part controls the movement of the player's hip
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
        {
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Z)) {
            Shoot();
        }
    }

    private void Shoot() //this part controls the player ship's ability to shoot
    {
        if (!_laserActive) 
        {
            Projectile projectile = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
            projectile.destroyed += LaserDestroyed;
            _laserActive = true;
        } 
    }

    private void LaserDestroyed() //this controls the outcome actions of when an invader is destroyed
    {
        _laserActive = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Invader") ||
            other.gameObject.layer == LayerMask.NameToLayer("Missile"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
    }

}
