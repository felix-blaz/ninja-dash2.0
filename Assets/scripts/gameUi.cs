using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameUi : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        spawnManager manager = new spawnManager();
        manager.isGameActive = false;
    }
}
