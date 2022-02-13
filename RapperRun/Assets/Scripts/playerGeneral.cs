using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerGeneral : MonoBehaviour
{
    public progressBar pb;

    public Color normalColor;
    public Color mcWannabeColor;
    public Color rapGodColor;
    
    public Text characterTxt;
    public Text levelTxt;

    public GameObject rapGodCrown;
    public GameObject mcWannaBeCowboyHat;
    private int characterLevel;
    private int level;

    public static int maxScore = 100;
    public static int score;


    void Awake(){
        level = PlayerPrefs.GetInt("level" , 1);
    }

    void Start()
    {
        levelTxt.text = "LEVEL " + level.ToString();   
        score = 50;
        pb.SetScore(playerGeneral.score);
        characterLevel = 0;
        rapGodCrown.SetActive(false);
        mcWannaBeCowboyHat.SetActive(false);
    }

    void Update(){
        checkForCharacter();
    }

    void checkForCharacter(){
        // Karakter seviyesini belirliyoruz (0'dan küçük olursa oyunu kaybediyor)
        if(score >= maxScore){
            // Eğer karakter maksimum seviyedeyse, skoru aynı tutuyoruz
            if(characterLevel == 2){
                score = 90;
                pb.SetScore(playerGeneral.score);
                return;
            }

            if(characterLevel < 2){
                playerAnim.sharedInstance.playerTransform();
                characterLevel++;
            }
            score = 0;
            pb.SetScore(playerGeneral.score);
        }
        if(score < 0){
            if(characterLevel > 0){
            playerAnim.sharedInstance.playerTransform();
            characterLevel--;
            score = 90;
            pb.SetScore(playerGeneral.score);
            }
            else if(characterLevel <= 0){
                playerManager.isDead = true;
            }
        }

        // Karakterin seviyesini kontrol edip ona göre eşya giydiriyoruz
        if(characterLevel == 0){
            Camera.main.backgroundColor = normalColor;
            characterTxt.text = "NORMAL";
            rapGodCrown.SetActive(false);
            mcWannaBeCowboyHat.SetActive(false);
        }
        else if(characterLevel == 1){
            Camera.main.backgroundColor = mcWannabeColor;
            characterTxt.text = "MC WANNABE";
            rapGodCrown.SetActive(false);
            mcWannaBeCowboyHat.SetActive(true);
        }
        else if(characterLevel == 2){
            Camera.main.backgroundColor = rapGodColor;
            characterTxt.text = "RAP GOD";
            rapGodCrown.SetActive(true);
            mcWannaBeCowboyHat.SetActive(false);
        }
    }
}
