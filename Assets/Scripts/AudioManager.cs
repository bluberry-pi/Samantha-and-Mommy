using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource momMusicSource;

    public AudioClip bg_music;
    public AudioClip mom_music;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        musicSource.clip = bg_music;
        musicSource.loop = true;
        musicSource.Play();

        momMusicSource.clip = mom_music;
        momMusicSource.loop = true;
    }

    public void PlayMomMusic()
    {
        if (momMusicSource.isPlaying) return;

        musicSource.Stop();
        momMusicSource.Play();
    }

    public void StopMomMusic()
    {
        if (!momMusicSource.isPlaying) return;

        momMusicSource.Stop();
        musicSource.Play();
    }
}