using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif



public class MenuUIHandler : MonoBehaviour
{
   
    private bool goodName=false;
    public InputField InputName;
    public Text inputName;
    public GameObject  menu;
    public GameObject  statistica; 
    public GameObject statisticaBakc;
    public string PlayerName;
    public Text player1;
    public Text player2;
    public Text player3;
    public Text player4;
    public Text player5;
    private void Start()
    {
       Score.Instance.LoadStat();
       player1.text = Score.Instance.iplayer1;
       player2.text = Score.Instance.iplayer2;
       player3.text = Score.Instance.iplayer3;
       player4.text = Score.Instance.iplayer4;
       player5.text = Score.Instance.iplayer5;

        //or simply use the line below, 
        //input.onEndEdit.AddListener(SubmitName);  // This also works
    }
    public void StartNew()
    {
        if(goodName)SceneManager.LoadScene(1);
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
      Score.Instance.SaveStat();
    }
    public void Back()
    {

        menu.SetActive(true);
        statistica.SetActive(false);
        statisticaBakc.SetActive(false);
    }
    public void statistic()
    {

        menu.SetActive(false);
        statistica.SetActive(true);
        statisticaBakc.SetActive(true);
    }
    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
        
    }
      public void EndEdit()
    {
        PlayerName= inputName.text;
        if (PlayerName=="")
        { 
            Debug.Log(PlayerName);
        }
        else
        {
            goodName = true;
        }
        Debug.Log(PlayerName);
        Score.Instance.newPlayer(PlayerName);


    }


}
