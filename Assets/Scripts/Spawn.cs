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

    // Start is called before the first frame update
    void Start()
    {
        StartLevel();
    }

    // Update is called once per frame
    void Update()
    {
        LevelFailedOrPassed();
    }

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
        Despawn.fallenCounter = 0;
        GoalReached.Counter = 0;
        StartCoroutine(SpawnCylinder());

        Debug.Log(SceneManager.sceneCountInBuildSettings);
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
    }

    void LevelFailedOrPassed()
    {
        // If the level has been failed
        if (Despawn.fallenCounter > GoalReached.Counter)
        {
            levelFailed.SetActive(true);

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        // If the level was passed successfully
        if(GoalReached.Counter == spawnPos.Length && 
            SceneManager.GetActiveScene().buildIndex + 1 != SceneManager.sceneCountInBuildSettings)
        {
            levelPassed.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else if(GoalReached.Counter == spawnPos.Length)
        {
            lastLevel.SetActive(true);

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if(levelFailed.activeSelf == true || levelPassed.activeSelf == true || 
            lastLevel.activeSelf == true)
        {
            exitToMenu.SetActive(true);

            // Implement Menu function
        }
    }
}
