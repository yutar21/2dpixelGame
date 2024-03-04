using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0; // Biến điểm số
    public TMP_Text scoreText; // Text hiển thị điểm số (TextMeshPro)

    void Start()
    {
        score = 0; // Khởi tạo điểm số ban đầu
        UpdateScoreText(); // Cập nhật hiển thị điểm số
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Apple")) // Kiểm tra nếu nhân vật chạm vào apple
        {
            score++; // Tăng điểm số
            UpdateScoreText(); // Cập nhật hiển thị điểm số
            Destroy(other.gameObject); // Hủy đối tượng apple sau khi chạm
        }
    }

    void UpdateScoreText()
    {
        // Cập nhật hiển thị điểm số trên giao diện người dùng
        scoreText.text = "Score: " + score.ToString();
    }
}
