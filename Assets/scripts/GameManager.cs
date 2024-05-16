using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Scores
{
    public List<int> scores = new List<int>();
}

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public Scores yourScore = new Scores();
    public int scoreStorage = 15;

    private void Awake()
    {
        // Making sure only 1 instance of GameManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadScores();  // Load scores when the game starts
            Debug.Log("PlayerPrefs Data: " + PlayerPrefs.GetString("Scores"));
           // DeleteAllScores();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StoreScore(int score)
    {
        // Add the score to the list
        yourScore.scores.Add(score);

        // Sort the scores in descending order
        yourScore.scores.Sort((a, b) => b.CompareTo(a));

        // Only use the top 15 scores
        if (yourScore.scores.Count > scoreStorage)
        {
            yourScore.scores = yourScore.scores.GetRange(0, scoreStorage);
        }

        // Save the scores
        SaveScores();
    }

    private void SaveScores()
    {
        // Serialize the score data to JSON
        string strOutput = JsonUtility.ToJson(yourScore);

        // Save the JSON to PlayerPrefs
        PlayerPrefs.SetString("Scores", strOutput);
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs Data: " + PlayerPrefs.GetString("Scores"));
    }

    private void LoadScores()
    {
        try
        {
            // Load existing scores from PlayerPrefs
            if (PlayerPrefs.HasKey("Scores"))
            {
                string json = PlayerPrefs.GetString("Scores");
                Scores loadedScores = JsonUtility.FromJson<Scores>(json);

                
                yourScore.scores.AddRange(loadedScores.scores);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error loading scores: " + e.Message);
        }
    }

    // to deletes all scores in the list
    public void DeleteAllScores()
    {
       
        yourScore.scores.Clear();

       
        SaveScores();
    }

    public static GameManager Instance
    {
        get { return instance; }
    }
}

