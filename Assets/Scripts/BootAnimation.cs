using UnityEngine;

public class BootAnimation : MonoBehaviour
{
    public GameObject Fadein;
    public GameObject Boot;
    public GameObject Canvas;

    public void DisableFadeAnimation()
    {
        Fadein.SetActive(false);
    }
    public void DisableBootAnimation()
    {
        Boot.SetActive(false);
        Canvas.SetActive(true);
    }
}