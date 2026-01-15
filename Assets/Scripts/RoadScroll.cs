using UnityEngine;

public class RoadScroll : MonoBehaviour
{
  public float speed = 2f; // скорость движения
    private Vector3 startPos;
    public float repeatWidth; // ширина текстуры (в юнитах)

    void Start()
    {
        startPos = transform.position;
        // Вычисляем ширину, если не указана вручную
        if (repeatWidth == 0)
            repeatWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // Смещаем дорогу влево
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Когда дорога ушла за экран, возвращаем её обратно
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
