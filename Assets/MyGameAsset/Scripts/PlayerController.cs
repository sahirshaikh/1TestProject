using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
// using EZCameraShake;

using UnityEngine.UI;


public class PlayerController : MonoBehaviour

{
    public Rigidbody2D rigidbody2d;
    public float speed;
    public float baseSpeed;
    public float sprint;




    public GameObject Gamewonpanel;
    public GameObject Gamepausepanel;
    public GameObject Gamelostpanel;


    // private bool IsGamewon = false;
    // private bool IsGamelost = false;

    void Start()
    {

        speed=baseSpeed;

    }


    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Player stop");
            // rigidbody2d.velocity = new Vector2(0f,0f);
            speed=0f;

       
        }


                if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = baseSpeed + sprint;
        }
        else
        {
            speed = baseSpeed;
        }

        // if(IsGamewon == true || IsGamelost == true)
        // {
        //     return;
        // }

        if(Input.GetAxis("Horizontal")>0)
        {
            rigidbody2d.velocity = new Vector2(speed,0f);
        }

        else if(Input.GetAxis("Horizontal")<0)
        {
            rigidbody2d.velocity = new Vector2(-speed,0f);
        }

        else if(Input.GetAxis("Vertical")>0)
        {
            rigidbody2d.velocity = new Vector2(0f,speed);
        }
        else if(Input.GetAxis("Vertical")<0)
        {
            rigidbody2d.velocity = new Vector2(0f,-speed);
        }

        else if(Input.GetAxis("Vertical")==0 && Input.GetAxis("Horizontal")==0 )
        {
            rigidbody2d.velocity = new Vector2(0f,0f);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Game Pause");
            Gamepausepanel.SetActive(true);
        
        }


      
       } 



        


        
    private void OnTriggerEnter2D(Collider2D other) {

         if(other.tag=="Checkpoint")
        {
            Debug.Log("Level Completed...!!!");
            Gamewonpanel.SetActive(true);
            // IsGamewon=true;
            speed = 0f;
            baseSpeed= 0f;
        }

            if(other.tag=="Enemy")
        {
            Debug.Log("You Lost...!!");
            Gamelostpanel.SetActive(true);
            // IsGamelost=true;
            speed = 0f;
            baseSpeed= 0f;
            // CameraShaker.Instance.ShakeOnce(4f,4f,0.1f,1f);
        }
       
    }

    public void RestartGame()
    {
        Debug.Log("Restart Game Clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

        public void NextLevelGame()
    {
        Debug.Log("Restart Game Clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

            public void PreviousLevelGame()
    {
        Debug.Log("Restart Game Clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void ResumeGame()
    {
        Debug.Log("Game Resumed");
        Gamepausepanel.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }





}

