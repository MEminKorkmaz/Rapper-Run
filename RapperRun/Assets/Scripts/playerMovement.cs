using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float lastFrameFingerPositionX;
    public float moveFactorX;

    [HideInInspector]
    public float moveSpeed = 3f;
    private float swerveSpeed = 2f;
    private float maxSwerveAmount = 2f;

    public static bool isStart;

    

    void Start(){
        isStart = false;
    }

    private void Update()
    {
        if(playerManager.isDead == true || playerManager.isEndGame == true || isStart == false){
            return;
        }

        transform.Translate(0f , 0f , moveSpeed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - lastFrameFingerPositionX;
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0f;
        }

        float swerveAmount = Time.deltaTime * swerveSpeed * moveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        transform.Translate(swerveAmount, 0f , 0f);

        // Ground sınırlarını aşmasını engelliyoruz
        if(transform.position.x <= -2.5f){
            transform.position = new Vector3(-2.5f , transform.position.y , transform.position.z);
        }
        if(transform.position.x >= 2.5f){
            transform.position = new Vector3(2.5f , transform.position.y , transform.position.z);
        }
    }
}