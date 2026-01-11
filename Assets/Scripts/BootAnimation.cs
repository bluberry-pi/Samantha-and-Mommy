using UnityEngine;

public class BootAnimation : MonoBehaviour
{
    public GameObject Fadein;
    public GameObject Boot;
    public GameObject Canvas;
    [SerializeField] private AudioClip bootSound;
    [SerializeField] private float volume = 0.5f;

    public void DisableFadeAnimation()
    {
        Fadein.SetActive(false);
    }
    public void DisableBootAnimation()
    {
        SoundFXManager.instance.PlaySoundFXClip(bootSound, transform, volume);
        Boot.SetActive(false);
        Canvas.SetActive(true);
    }
}