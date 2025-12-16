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

    //sets deathcount to be able to be read publicaly but only set in this script
    public int deathCount {  get; private set; }

    private void Awake()
    {
        //if no instances then assign this one
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            //destroys duplicate instances
            Destroy(gameObject);
        }
    }

    //called when the play button is clicked
    public void PlayGame()
    {
        //makes sure that playmode can only be enabled once
        if (!Global.PlayMode)
        {
            Global.PlayMode = true;

            //hides the play button once clicked
            playButton.gameObject.SetActive(false);
        }
    }

    //puts the player back to the respawn point when ResetSpawn is called
    public void ResetSpawn()
    {
        player.transform.position = respawnPoint.position;
    }

    public void PlayerDied()
    {
        //when the player dies the death counter is increased by 1
        deathCount++;
       
        //update the on screen death counter
        Debug.Log("deaths: " +  deathCount);
        
        //calls resetspawn and resetallalides
        ResetSpawn();
        ResetAllSlides();
    }

    //sets all the moving sprites back to being hidden
    public void ResetAllSlides()
    {
        foreach (SlideUp slide in SlideUp.AllSlides)
        {
            slide.ResetPosition();
        }
    }

    //called when the player wins
    public void WinGame()
    {
        //stops gameplay
        Time.timeScale = 0f;      

        //display the winscreen
        winScreen.SetActive(true);
    }
}
