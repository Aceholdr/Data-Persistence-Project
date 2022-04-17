using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIMenuManager : MonoBehaviour
{
    public Button[] levelButtons;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Button button in levelButtons)
        {
            button.onClick.AddListener(delegate { ClickToLevel(button); });
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    // Launches the clicked Level
    void ClickToLevel(Button button)
    {
        string level = button.GetComponentInChildren<TextMeshProUGUI>().text;

        SceneManager.LoadScene("Level" + level);
    }
}
