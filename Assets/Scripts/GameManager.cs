using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Button playButton;
    [SerializeField] private Button resetButton;
    public Transform respawnPoint;
    public GameObject player;

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
}
