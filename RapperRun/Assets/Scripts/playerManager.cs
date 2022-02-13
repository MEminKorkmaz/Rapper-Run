using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerManager : MonoBehaviour
{
    public progressBar pb;
    public GameObject collectPSPrefab;

    public int goldenItemScore;
    public int badItemScore;
    public int goldenGateScore;
    public int badGateScore;

    public static bool isDead;
    public static bool isEndGame;

    void Start(){
        isDead = false;
        isEndGame = false;
        pb.SetMaxScore(playerGeneral.maxScore);
    }


    void OnCollisionEnter(Collision col){
        if(col.gameObject.CompareTag("goldenItems")){
            //Karakterimize, seviye atlaması için skor ekliyoruz
            playerGeneral.score += goldenItemScore;
            pb.SetScore(playerGeneral.score);
            GameObject go = Instantiate(collectPSPrefab , transform.position , transform.rotation);
            Destroy(go , 1f);
            Destroy(col.gameObject);
        }
        if(col.gameObject.CompareTag("badItems")){
            playerGeneral.score += badItemScore;
            pb.SetScore(playerGeneral.score);
            GameObject go = Instantiate(collectPSPrefab , transform.position , transform.rotation);
            Destroy(go , 1f);
            Destroy(col.gameObject);
        }
        if(col.gameObject.CompareTag("goldenGate")){
            playerGeneral.score += goldenGateScore;
            pb.SetScore(playerGeneral.score);
            GameObject go = Instantiate(collectPSPrefab , transform.position , transform.rotation);
            Destroy(go , 1f);
            Destroy(col.transform.parent.gameObject);
        }
        if(col.gameObject.CompareTag("badGate")){
            playerGeneral.score += badGateScore;
            pb.SetScore(playerGeneral.score);
            GameObject go = Instantiate(collectPSPrefab , transform.position , transform.rotation);
            Destroy(go , 1f);
            Destroy(col.transform.parent.gameObject);
        }

        if(col.gameObject.CompareTag("endGame")){
            endGame();
        }
    }

    void endGame(){
        isEndGame = true;
        playerAnim.sharedInstance.endGame();
    }
}
