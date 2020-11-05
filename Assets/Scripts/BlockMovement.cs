using System.Collections;
using UnityEngine;

public class BlockMovement : MonoBehaviour {
    public GameObject dash;

    public float stopPos;
    public float speed;
    private float previousX;

    private bool canDestroy = false;
    public bool canMove = true;

    private void Start() {
        StartCoroutine(MoveTrigger());
    }

    private void Update() {
        Slide();
    }

    private float distanceMade = 0f;
    private readonly float maxDistance = 1f;

    private void Slide() {
        if(canMove && !CompareTag("Shadow")) {
            if(transform.position.x < stopPos && distanceMade < maxDistance) {
                previousX = Mathf.Abs(transform.position.x);
                transform.Translate(Vector2.right * speed * Time.deltaTime, Space.Self);
                distanceMade += Mathf.Abs(Mathf.Abs(transform.position.x) - previousX);
            } else {
                canMove = false;
                if (transform.position.x >= stopPos && canDestroy) {
                    Attack();
                }
            } 
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Stop")) {
            Color color = GetComponent<SpriteRenderer>().color;
            if (color.b > 0 && color.g > 0) {
                color.b -= 0.05f;
                color.g -= 0.05f;
                GetComponent<SpriteRenderer>().color = color;
            }
        }
    }

    private IEnumerator MoveTrigger() {
        while(true) {
            yield return new WaitUntil(() => canMove == false);
            yield return new WaitForSeconds(FindObjectOfType<BlockSpawner>().timeBtwSpawns/2);
            if (transform.position.x >= stopPos)
                canDestroy = true;
            canMove = true;
            distanceMade = 0f;
        }

    }

    private void Attack() {
        if(!CompareTag("Shadow"))
            dash = Instantiate(dash, new Vector2(transform.position.x, transform.position.y), new Quaternion(0, 0, 0, 0));
        Destroy(gameObject);
        Destroy(dash, 0.05f);
    }
}
