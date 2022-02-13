using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startManager : MonoBehaviour
{
    public GameObject startPanel;

    void Start(){
        startPanel.SetActive(true);
    }
    public void startGame(){
        playerMovement.isStart = true;
        startPanel.SetActive(false);
    }
}
