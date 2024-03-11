using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float pushForce = 25f; // Lực đẩy lùi khi va chạm với lưỡi cưa

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Saw")) // Kiểm tra va chạm với lưỡi cưa
        {
            // Xác định hướng va chạm
            Vector2 direction = transform.position - other.transform.position;
            direction.Normalize();

            // Áp dụng lực đẩy lùi
            GetComponent<Rigidbody2D>().AddForce(direction * pushForce, ForceMode2D.Impulse);

            // Giảm số mạng sống từ GameManager
           // GameManager.instance.DecreaseLife();
        }
    }
}
