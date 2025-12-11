using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 6f;
    public int damage = 1;
    public float lifeTime = 3f;

    private float direction = 1f;
    private Rigidbody2D rig;
    private float lifeTimer;

    void OnEnable()
    {
        lifeTimer = lifeTime;
        if (rig == null)
            rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // movimento
        rig.linearVelocity = new Vector2(direction * speed, rig.linearVelocity.y);

        // vida
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0)
            gameObject.SetActive(false);
    }

    public void SetDirection(float dir)
    {
        direction = Mathf.Sign(dir);

        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * Mathf.Sign(dir);
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // acerta player
        Player p = collision.GetComponent<Player>();
        if (p != null)
        {
            p.TomarDano(damage);
            gameObject.SetActive(false);
            return;
        }

        // bate no chão
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground") ||
            collision.CompareTag("Chão"))
        {
            gameObject.SetActive(false);
        }
    }
}
