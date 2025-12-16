using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject winScreen;

    [SerializeField] private Button playButton;
    [SerializeField] private Button resetButton;
    public Transform respawnPoint;
    public GameObject player;

    public int deathCount {  get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayGame()
    {
        if (!Global.PlayMode)
        {
            Global.PlayMode = true;
            playButton.gameObject.SetActive(false);
        }
    }

    public void ResetSpawn()
    {
        player.transform.position = respawnPoint.position;
    }

    public void PlayerDied()
    {
        deathCount++;
        Debug.Log("deaths: " +  deathCount);
        ResetSpawn();
    }

    public void ResetAllSlides()
    {
        foreach (SlideUp slide in SlideUp.AllSlides)
        {
            slide.ResetPosition();
        }
    }

    public void WinGame()
    {
        Time.timeScale = 0f;       // stop the game
        winScreen.SetActive(true); // show win screen
    }
}
