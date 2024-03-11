using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Thể hiện tĩnh của lớp GameManager

    public int maxLife = 3; // Số mạng sống tối đa
    public int life; // Số mạng sống hiện tại
    public GameObject lifePrefab; // Prefab cho mạng sống
    public Transform lifePanel; // Panel chứa các mạng sống
    public GameObject gameOverPanel; // Panel hiển thị game over

    void Awake()
    {
        // Gán thể hiện tĩnh cho biến instance khi game bắt đầu
        instance = this;
    }

    void Start()
    {
        life = maxLife; // Khởi tạo số mạng sống
        InstantiateLife(); // Hiển thị số mạng sống trên giao diện người dùng
        gameOverPanel.SetActive(false); // Ẩn panel game over ban đầu
    }

    void InstantiateLife()
    {
        // Hiển thị số mạng sống trên giao diện người dùng
        for (int i = 0; i < life; i++)
        {
            Instantiate(lifePrefab, lifePanel);
        }
    }

    public void DecreaseLife()
    {
        life--; // Giảm số mạng sống
        DestroyLife(); // Xóa mạng sống trên giao diện người dùng
        if (life <= 0)
        {
            // Hiển thị game over khi số mạng sống hết
            gameOverPanel.SetActive(true);
            Time.timeScale = 0; // Tạm dừng game
        }
    }

    void DestroyLife()
    {
        // Xóa mạng sống trên giao diện người dùng
        foreach (Transform child in lifePanel)
        {
            Destroy(child.gameObject);
        }
    }
}
