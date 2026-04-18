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
        _targetPos = transform.position;
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
        if (!IsAlive) return; 
        
        Health -= damage;
        Text.text = Health.ToString();
        
        if (Health <= 0)
        {
            Die(); 
        }
    }
    
    private void Die()
    {
        IsAlive = false;
        
        
        OnPlayerDeath?.Invoke();
        
        
        Debug.Log("Player died!");
        
        
        Destroy(gameObject, 0.1f);
    }
}