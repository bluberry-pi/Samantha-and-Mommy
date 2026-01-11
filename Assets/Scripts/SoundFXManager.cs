using UnityEngine;
using System.Collections;
public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;
    [SerializeField] private AudioSource soundFXObject;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume, float pitch = 1f)
    {
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.Play();
        Destroy(audioSource.gameObject, audioSource.clip.length / pitch);
    }

    public IEnumerator PlayAndWait(AudioClip clip, Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.Play();

        yield return new WaitForSeconds(audioSource.clip.length);

        Destroy(audioSource.gameObject);
    }

}
