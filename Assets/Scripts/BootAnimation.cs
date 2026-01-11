using UnityEngine;

public class BootAnimation : MonoBehaviour
{
    public GameObject Fadein;
    public GameObject Boot;
    public GameObject Canvas;
    [SerializeField] private AudioClip bootSound;

    public void DisableFadeAnimation()
    {
        Fadein.SetActive(false);
    }
    public void DisableBootAnimation()
    {
        SoundFXManager.instance.PlaySoundFXClip(bootSound, transform, 1f);
        Boot.SetActive(false);
        Canvas.SetActive(true);
    }
}