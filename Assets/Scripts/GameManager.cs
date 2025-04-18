using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Button _startButton;

    [SerializeField]
    private Transform _canvasTrans;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        _startButton.onClick.AddListener(OnStartButtonClicked);
    }
    private void OnStartButtonClicked()
    {
        _startButton.gameObject.SetActive(false);
        GameObject resGo = Resources.Load<GameObject>("Prefab/ModeUI");
        GameObject sceanGo = Instantiate(resGo,_canvasTrans,false);
        ModeUI uiComp = sceanGo.GetComponent<ModeUI>();
        uiComp.AddTimeClickEvent(OnClickTimeAttackMode);
        uiComp.AddStageClickEvent(OnClickStageMode);
    }
    private void OnClickTimeAttackMode()
    {
        StartCoroutine(LoadSceneAsync("GameScene2"));
    }
    private IEnumerator LoadSceneAsync(string scene)
    {
        yield return SceneManager.LoadSceneAsync(scene);

        GameObject resGo= Resources.Load<GameObject>("Prefab/PangPlayer");
        Instantiate(resGo);
    }
    private void OnClickStageMode()
    {
        Debug.Log("Stage Mode");
    }
    // Update is called once per frame
}
