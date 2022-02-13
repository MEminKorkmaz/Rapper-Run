using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class failPanelManager : MonoBehaviour
{
    public GameObject failPanel;



    void Start(){
        failPanel.SetActive(false);
    }

    void Update(){
        // Karakter öldüğü zaman, Fail panelini açıyoruz
        if(playerManager.isDead){
            failPanel.SetActive(true);
        }
    }

    public void TryAgain(){
        playerManager.isDead = false;
        failPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
