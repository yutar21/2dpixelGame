
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManeger : MonoBehaviour
{
    //private AudioSource myAudioSource;

    void Start()
    {
    //    myAudioSource = GetComponent<AudioSource>();
     //   myAudioSource.Play(); // Play the music on scene start
    }
    void Update()
    {
        onclickGame();
    }
    void onclickGame()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
    }
}
