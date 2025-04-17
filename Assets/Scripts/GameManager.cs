using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] 
    private Button _startButton;
    [SerializeField]
    private Transform _canVasTrans;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        _startButton.onClick.AddListener(OnClickStartButton);
    }
    private void OnClickStartButton()
    {
        _startButton.gameObject.SetActive(false);
        GameObject resGo = Resources.Load<GameObject>("Prefabs/ModeUI");
        Debug.Log("resGo : "+resGo);
        GameObject SceanGo = Instantiate(resGo, _canVasTrans, false);
        ModeUI uiComp = SceanGo.GetComponent<ModeUI>();
        uiComp.OnClickTimeClickEvent(OnClickTimeAttackMode);
    }
    private void OnClickTimeAttackMode()
    {
        Debug.Log("Time Attack Mode Clicked");
        StartCoroutine(LoadSceneAsync("SampleScene"));
    }
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName);
        
        GameObject player = Resources.Load<GameObject>("Prefabs/PangPlayer");
        Instantiate(player);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
