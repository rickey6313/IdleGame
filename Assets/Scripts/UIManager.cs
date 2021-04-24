using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField]
    private GameObject inventoryPanel;

    [SerializeField]
    private GameObject WaitingPanel;

    [SerializeField]
    private FadeController fadeController;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        Instance = this;
    }

    public void SetActiveInventoryPanel(bool value)
    {
        inventoryPanel.SetActive(value);
    }

    public void SwitchInventoryUI()
    {
        if (inventoryPanel.activeInHierarchy)
            inventoryPanel.SetActive(false);
        else
            inventoryPanel.SetActive(true);
    }

    public void SetActiveWaitingPanel(bool value)
    {
        inventoryPanel.SetActive(value);
    }

    public void SwitchWaitingPanelUI()
    {
        if (WaitingPanel.activeInHierarchy)
            WaitingPanel.SetActive(false);
        else
            WaitingPanel.SetActive(true);
    }

    public IEnumerator FadeIn()
    {
        yield return fadeController.FadeInRoutine();
    }

    public IEnumerator FadeOut()
    {
        yield return fadeController.FadeOutRoutine();
    }

    private void Update()
    {
        
    }

    private void CheckInput()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            SwitchInventoryUI();
        }
        
        if (Input.GetKeyUp(KeyCode.I))
        {

        }

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            StartCoroutine(SceneController.instance.LoadSceneAsync("Level1"));
        }
    }
}
