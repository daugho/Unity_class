using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ModeUI : MonoBehaviour
{
    [SerializeField]
    Button _timeAttackButton;
    [SerializeField]
    Button _stageModeButton;

    public void OnClickTimeClickEvent(UnityAction clickCallback)
    {
        _timeAttackButton.onClick.AddListener(clickCallback);
    }
    public void OnClickStageClickEnent(UnityAction clickCallback)
    {
        _stageModeButton.onClick.AddListener(clickCallback);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
