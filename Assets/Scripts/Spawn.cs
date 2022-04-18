using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;
    public Vector3[] spawnPos;
    public int timeBetweenSpawns = 2;

    public GameObject levelFailed;
    public GameObject levelPassed;
    public GameObject lastLevel;
    public GameObject exitToMenu;

    private AudioSource levelAudioSource;
    public AudioClip nextLevelSound;
    public AudioClip backToMenuSound;
    public AudioClip retrySound;

    // Start is called before the first frame update
    void Start()
    {
        levelAudioSource = GetComponent<AudioSource>();
        StartLevel();
    }

    // Update is called once per frame
    void Update()
    {
        LevelFailedOrPassed();
    }

    // Spawns the wheels in a set amount of time
    IEnumerator SpawnCylinder()
    {
        for(int i = 0; i < spawnPos.Length; i++)
        {      
            Instantiate(prefab, spawnPos[i], Quaternion.Euler(90,0,0));

            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    void StartLevel()
    {
        Despawn.FallenCounter = 0;
        GoalReached.Counter = 0;
        StartCoroutine(SpawnCylinder());
    }

    // Decides if one wheel has fallen off, or if everyone has reached the goal
    void LevelFailedOrPassed()
    {
        // If the level has been failed
        if (Despawn.FallenCounter > GoalReached.Counter)
        {
            levelFailed.SetActive(true);

            if (Input.GetKeyDown(KeyCode.R))
            {
                levelAudioSource.PlayOneShot(retrySound);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        // If the level was passed successfully
        if(GoalReached.Counter == spawnPos.Length && 
            SceneManager.GetActiveScene().buildIndex + 1 != SceneManager.sceneCountInBuildSettings)
        {
            levelPassed.SetActive(true);

            SaveSaveData();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                levelAudioSource.PlayOneShot(nextLevelSound);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                levelAudioSource.PlayOneShot(retrySound);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        // The last level
        else if(GoalReached.Counter == spawnPos.Length)
        {
            lastLevel.SetActive(true);
            SaveSaveData();

            if (Input.GetKeyDown(KeyCode.R))
            {
                levelAudioSource.PlayOneShot(retrySound);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        // Every instance gives you the option to quit
        if(levelFailed.activeSelf == true || levelPassed.activeSelf == true || 
            lastLevel.activeSelf == true)
        {
            exitToMenu.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                levelAudioSource.PlayOneShot(backToMenuSound);
                SceneManager.LoadScene(0);
            }
        }
    }

    // Marks the current level as beaten
    void SaveSaveData()
    {
        if(SaveManager.Instance.BeatenLevel < SceneManager.GetActiveScene().buildIndex)
        {
            SaveManager.Instance.BeatenLevel++;
            SaveManager.Instance.SaveProgress();
        }     
    }
}
