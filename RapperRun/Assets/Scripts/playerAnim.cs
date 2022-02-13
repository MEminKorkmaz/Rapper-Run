using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnim : MonoBehaviour
{
    public static playerAnim sharedInstance;
    
    public Animator anim;

    void Awake(){
        sharedInstance = this;
    }

    // Karakter dönme animasyonu (karakterin seviyesi arttıktan sonra)
    public void playerTransform(){
        anim.SetTrigger("playerUpgrade");
    }

    public void endGame(){
        anim.SetTrigger("endGame");
    }
}
