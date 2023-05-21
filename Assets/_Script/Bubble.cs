using UnityEngine;

public class Bubble : MonoBehaviour
{
    public Rigidbody2D candyRigidbody;
    private bool isLifting = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Candy>())
        {
            isLifting = true;
            collision.gameObject.transform.SetParent(transform);
            candyRigidbody.simulated = false; // Отключаем физику конфеты
        }
    }

    void Update()
    {
        if (isLifting)
        {
            transform.Translate(Vector3.up * Time.deltaTime); // Поднимаем пузырёк вверх
        }
    }
}

