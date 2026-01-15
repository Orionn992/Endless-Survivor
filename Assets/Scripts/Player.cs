using UnityEngine;
using TMPro;
using System; // Добавляем для использования Action

public class Player : MonoBehaviour
{
    public static event Action OnPlayerDeath; // Событие смерти игрока
    
    public int Health;
    public float Speed;
    public float YIncrement;
    public float MinHeight, MaxHeight;
    public TMP_Text Text;
    
    public bool IsAlive { get; private set; } = true; // Свойство для проверки состояния

    private Vector2 _targetPos = Vector2.zero;

    private void Start()
    {
        Text.text = Health.ToString();
    }

    private void Update()
    {
        if (!IsAlive) return; // Если игрок мертв, прекращаем движение
        
        transform.position = Vector2.MoveTowards(transform.position, _targetPos, Speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W) && _targetPos.y < MaxHeight)
        {
            _targetPos = new Vector2(_targetPos.x, _targetPos.y + YIncrement);
        }
        else if(Input.GetKeyDown(KeyCode.S) && _targetPos.y > MinHeight)
        {
            _targetPos = new Vector2(_targetPos.x, _targetPos.y - YIncrement);
        }
    }

    public void ApplyDamage(int damage)
    {
        if (!IsAlive) return; // Если уже мертв, не обрабатываем урон
        
        Health -= damage;
        Text.text = Health.ToString();
        
        if (Health <= 0)
        {
            Die(); // Вызываем метод смерти
        }
    }
    
    private void Die()
    {
        IsAlive = false;
        
        // Вызываем событие смерти
        OnPlayerDeath?.Invoke();
        
        // Можно добавить визуальные эффекты перед уничтожением
        Debug.Log("Player died!");
        
        // Уничтожаем объект с небольшой задержкой
        Destroy(gameObject, 0.1f);
    }
}