using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endGameManager : MonoBehaviour
{
    public GameObject endGamePanel;
    public Text levelCompletedTxt;


    void Start(){
        endGamePanel.SetActive(false);
        int tempLevel = PlayerPrefs.GetInt("level" , 1);
        levelCompletedTxt.text = "Level " + tempLevel.ToString() + " Completed";
    }

    public void nextLevel(){
        int level = PlayerPrefs.GetInt("level" , 1);
        level += 1;
        PlayerPrefs.SetInt("level" , level);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        endGamePanel.SetActive(false);
    }

    void Update(){
        // Karakter bölüm sonuna zaman, endgame panelini açıyoruz
        if(playerManager.isEndGame){
            endGamePanel.SetActive(true);
        }
    }
}
