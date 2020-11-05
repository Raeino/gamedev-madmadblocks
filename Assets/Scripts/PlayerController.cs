using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float speedMod;
    private float moveInput;

    public GameObject explosion;
    public bool wallRed = false;

    private void FixedUpdate() {
        moveInput = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
            moveInput *= speedMod;
            wallRed = true;
        } else
            wallRed = false;

        transform.position = new Vector2(transform.position.x, transform.position.y + moveInput * speed * Time.fixedDeltaTime);

        if (wallRed)
            DeadlyWall();
        else
            NotDeadlyWall();

    }

    public Animator camAnim;

    private void Death() {
        explosion = Instantiate(explosion);
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        camAnim.SetTrigger("Shake");
        Destroy(gameObject);
        Destroy(explosion, 0.93f);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Death") || (collision.gameObject.CompareTag("Wall") && wallRed)) {
            Death();
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if ((collision.gameObject.CompareTag("Wall") && wallRed)) {
            Death();
        }
    }

    public GameObject wall1;
    public GameObject wall2;

    private void DeadlyWall() {
        wall1.GetComponent<SpriteRenderer>().color = new Color(1, 0.3f, 0.3f);
        wall2.GetComponent<SpriteRenderer>().color = new Color(1, 0.3f, 0.3f);
        gameObject.GetComponent<TrailRenderer>().enabled = true;
    }

    private void NotDeadlyWall() {
        wall1.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        wall2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        gameObject.GetComponent<TrailRenderer>().enabled = false;
    }

}
