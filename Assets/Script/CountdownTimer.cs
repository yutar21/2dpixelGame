using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 60f; // Thời gian ban đầu
    public TMP_Text countdownText; // Thể hiện thời gian còn lại

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // Giảm thời gian mỗi khung hình
            DisplayTime(timeRemaining);
        }
        else
        {
            // Xử lý khi thời gian kết thúc
            timeRemaining = 0;
            Debug.Log("Time's up!");
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
