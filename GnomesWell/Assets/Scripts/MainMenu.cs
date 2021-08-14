using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneToLoad;

    public RectTransform loadingOverlay;

    public RectTransform startGameButton;

    AsyncOperation sceneLoadingOperation;

    void Start()
    {
        startGameButton.gameObject.SetActive(true);

        loadingOverlay.gameObject.SetActive(false);

        sceneLoadingOperation = SceneManager.LoadSceneAsync(sceneToLoad);

        sceneLoadingOperation.allowSceneActivation = false;
    }

    public void LoadScene()
    {
        loadingOverlay.gameObject.SetActive(true);

        sceneLoadingOperation.allowSceneActivation = true;

        startGameButton.gameObject.SetActive(false);
    }
}
