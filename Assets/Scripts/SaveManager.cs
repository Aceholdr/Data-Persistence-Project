using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public int beatenLevel;
    }

    //Save and Load...
}
