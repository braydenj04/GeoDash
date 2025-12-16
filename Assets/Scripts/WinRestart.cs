using UnityEngine;
using UnityEngine.SceneManagement;

public class WinRestart : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
