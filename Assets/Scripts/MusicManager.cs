using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    private static MusicManager Instance;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    public AudioClip backgroundMusic;
    public AudioClip jumpSound;
    [SerializeField] private Slider musicSlider;


    private void Awake()
    {
        //if no instance exists then set this as the instance
        if (Instance  == null)
        {
            Instance = this;

            //get the audio source 
            musicSource = GetComponent<AudioSource>();

            //stops the object from being destroyed when changing scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //plays the background music when game starts
        if (backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }

        //initialises the slider and then updates the volume based on where the slider is set
        if (musicSlider != null)
        {
            musicSlider.value = musicSource.volume;
            musicSlider.onValueChanged.AddListener(setVolume);
        }
    }

    //plays background music (some of this is not used as i never got around to it)
    public void PlayBackgroundMusic(bool resetSong, AudioClip audioClip = null)
    {
        if(audioClip != null)
        {
           musicSource.clip = audioClip;
        }
        if(musicSource.clip != null)
        {
            if (resetSong)
            {
                musicSource.Stop();
            }
            musicSource.Play();
        }
    }

    //sets the volume of the background music according to the slider
    public static void setVolume(float volume)
    {
        Instance.musicSource.volume = volume;
    }

    //pauses the background music if called upon
    public void PauseBackgroundMusic()
    {
        musicSource.Pause();
    }

    void Update()
    {
        //checks if the space button is pressed, if yes then playjumpsound is called
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayjumpSound();
        }
    }

    //plays the jump noise
    public void PlayjumpSound()
    {
        if (jumpSound != null)
        {
            sfxSource.PlayOneShot(jumpSound);
        }
    }
}
