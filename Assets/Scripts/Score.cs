using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text Text;
    public GameObject player; // Ссылка на игрока
    
    private int _score;
    
    private void Start()
    {
        // Автоматически находим игрока, если не назначен в инспекторе
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Проверяем, существует ли игрок
            if (player != null)
            {
                _score++;
                Text.text = _score.ToString();
            }
        }
    }
}