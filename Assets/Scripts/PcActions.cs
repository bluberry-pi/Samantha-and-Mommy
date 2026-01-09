using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PcActions : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject updateScreen;
    public float waitAfterLoad = 3f;
    public GameObject Updating;
    public GameObject paintArea;
    public Transform paintParent;
    public Transform uiParent;
    public GameObject passwordWindow;

    Button proceedBtn;

    GameObject updateInstance;
    GameObject loadingInstance;
    GameObject paintWindow;

    bool cancelled = false;
    bool passwordSpawned = false;

    void OnEnable()
    {
        DownloadManager.OnDownloadComplete += SpawnPasswordWindow;

        // If download already finished earlier, spawn immediately
        if (DownloadManager.DownloadFinished)
            SpawnPasswordWindow();
    }

    void OnDisable()
    {
        DownloadManager.OnDownloadComplete -= SpawnPasswordWindow;
    }

    void Update()
    {
        if (!cancelled && loadingInstance == null)
            CancelEverything();

        if (!updateInstance) return;

        float z = updateInstance.transform.eulerAngles.z;

        if (IsNear(z, 0f)) Debug.Log("0 degrees");
        else if (IsNear(z, 270f)) Debug.Log("-90 degrees");
        else if (IsNear(z, 180f)) Debug.Log("-180 degrees");
        else if (IsNear(z, 90f)) Debug.Log("-270 degrees");
    }

    public void OnGamePress()
    {
        cancelled = false;
        StartCoroutine(LoadSequence());
    }

    public void onPaintPress()
    {
        paintWindow = Instantiate(paintArea, paintParent);
        WindowLayerManager.Instance.BringToFront(paintWindow);
    }

    IEnumerator LoadSequence()
    {
        loadingInstance = Instantiate(loadingScreen, uiParent);
        WindowLayerManager.Instance.BringToFront(loadingInstance);

        yield return new WaitForSeconds(waitAfterLoad);
        if (cancelled) yield break;

        updateInstance = Instantiate(updateScreen, uiParent);
        WindowLayerManager.Instance.BringToFront(updateInstance);

        proceedBtn = updateInstance.GetComponentInChildren<Button>();
        proceedBtn.onClick.RemoveAllListeners();
        proceedBtn.onClick.AddListener(OnProceedPress);
    }

    public void OnProceedPress()
    {
        if (cancelled) return;

        GameObject u = Instantiate(Updating, uiParent);
        WindowLayerManager.Instance.BringToFront(u);

        Destroy(updateInstance);
    }

    void SpawnPasswordWindow()
    {
        if (passwordSpawned) return;      // only spawn once
        passwordSpawned = true;

        if (!passwordWindow || !uiParent) return;

        GameObject pw = Instantiate(passwordWindow, uiParent);
        WindowLayerManager.Instance.BringToFront(pw);
    }

    void CancelEverything()
    {
        cancelled = true;
        StopAllCoroutines();

        if (updateInstance) Destroy(updateInstance);
        if (loadingInstance) Destroy(loadingInstance);
    }

    bool IsNear(float a, float b)
    {
        return Mathf.Abs(Mathf.DeltaAngle(a, b)) < 2f;
    }
}