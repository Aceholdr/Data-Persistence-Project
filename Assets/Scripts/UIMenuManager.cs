using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIMenuManager : MonoBehaviour
{
    public Button[] levelButtons;
    public GameObject[] stars;

    private AudioSource menuAudio;
    public AudioClip clickSound;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Button button in levelButtons)
        {
            button.onClick.AddListener(delegate { ClickToLevel(button); });
            button.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        menuAudio = GetComponent<AudioSource>();
        LoadSaveData();
    }

    // Launches the clicked Level
    void ClickToLevel(Button button)
    {
        menuAudio.PlayOneShot(clickSound);
        string level = button.GetComponentInChildren<TextMeshProUGUI>().text;

        SceneManager.LoadScene("Level" + level);
    }

    void LoadSaveData()
    {
        SaveManager.Instance.LoadProgress();

        if(SaveManager.Instance.BeatenLevel < levelButtons.Length)
        {
            for (int i = 0; i < SaveManager.Instance.BeatenLevel + 1; i++)
            {
                levelButtons[i].gameObject.SetActive(true);

                if (i >= 1)
                {
                    stars[i - 1].gameObject.SetActive(true);
                }
            }
        }
        else
        {
            for (int i = 0; i < levelButtons.Length; i++)
            {
                levelButtons[i].gameObject.SetActive(true);

                stars[i].gameObject.SetActive(true);
            }
        }
    }

    private void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            SaveManager.Instance.BeatenLevel = 0;
            SaveManager.Instance.SaveProgress();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
Application.Quit();
#endif
    }
}
