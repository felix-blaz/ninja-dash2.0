using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreBoard : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");
 
        entryTemplate.gameObject.SetActive(false);

        // Read in scores from PlayerPrefs
        string playerPrefsData = PlayerPrefs.GetString("Scores");
        Scores playerScores = JsonUtility.FromJson<Scores>(playerPrefsData);

        // Create a list of HighscoreEntrys from the player's scores
        highscoreEntryList = new List<HighscoreEntry>();
        foreach (int score in playerScores.scores)
        {
            highscoreEntryList.Add(new HighscoreEntry { score = score });
        }

        // Sort the list by score in descending order
        highscoreEntryList.Sort((a, b) => b.score.CompareTo(a.score));

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighScoreEntry(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    private void CreateHighScoreEntry(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        // Create a new entry from the template
        Transform entryTransform = Instantiate(entryTemplate, container);
        entryTransform.gameObject.SetActive(true);

        // Set the position of the entry in the container
        RectTransform rectTransform = entryTransform.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0, -50f * transformList.Count);


        // fill it with labels
        int rank = transformList.Count + 1;
        string rankString = GetRankString(rank);
        entryTransform.Find("posText").GetComponent<Text>().text = rankString;
        entryTransform.Find("scoreText").GetComponent<Text>().text = highscoreEntry.score.ToString();

        // Add the entry to the list
        transformList.Add(entryTransform);
    }

    private string GetRankString(int rank)
    {
        switch (rank)
        {
            case 1: return "1ST";
            case 2: return "2ND";
            case 3: return "3RD";
            default: return rank + "TH";
        }
    }

    [System.Serializable]
    private class Scores
    {
        public List<int> scores = new List<int>();
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
    }
}
