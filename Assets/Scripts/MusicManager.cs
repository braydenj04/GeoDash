using UnityEngine;
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
        if (Instance  == null)
        {
            Instance = this;
            musicSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }

        if (musicSlider != null)
        {
            musicSlider.value = musicSource.volume;
            musicSlider.onValueChanged.AddListener(setVolume);
        }
    }

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

    public static void setVolume(float volume)
    {
        Instance.musicSource.volume = volume;
    }

    public void PauseBackgroundMusic()
    {
        musicSource.Pause();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayjumpSound();
        }
    }

    public void PlayjumpSound()
    {
        if (jumpSound != null)
        {
            sfxSource.PlayOneShot(jumpSound);
        }
    }
}
