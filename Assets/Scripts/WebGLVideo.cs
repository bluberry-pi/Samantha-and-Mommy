using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class WebGLCutscene : MonoBehaviour
{
    public VideoPlayer player;
    public string videoFileName = "cutscene.mp4";
    public int nextSceneIndex = 2;
    bool loading = false;

    void Start()
    {
        string url = Application.streamingAssetsPath + "/" + videoFileName;

#if UNITY_WEBGL && !UNITY_EDITOR
    url = url.Replace("StreamingAssets", "StreamingAssets");
#endif

        player.url = url;
        player.loopPointReached += OnVideoEnd;
        player.Play();
    }


    void OnVideoEnd(VideoPlayer vp)
    {
        LoadNext();
    }

    public void SkipCutscene()
    {
        LoadNext();
    }

    void LoadNext()
    {
        if (loading) return;
        loading = true;
        SceneManager.LoadScene(nextSceneIndex);
    }
}