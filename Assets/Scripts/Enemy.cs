using UnityEngine;

public class Enemy : MonoBehaviour
{
public int Damage; 
public float Speed;

void Update()
{
    transform.Translate(Vector2.left * Speed * Time.deltaTime);

}

    private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Player"))
    {
        collision.GetComponent<Player>().ApplyDamage(Damage);
        Destroy(gameObject);
    }

}

}
