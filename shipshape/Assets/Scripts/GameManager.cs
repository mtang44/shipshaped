using UnityEngine;

using System;
using System.Collections.Generic;
using System.Linq;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public enum GameState
    {
        MAINMENU,
        INGAME,
        LEVELCOMPLETE,
        GAMEOVER
    }
    public GameState state;

    private static GameManager theInstance;
    public static GameManager Instance
    {
        get
        {
            if (theInstance == null)
                theInstance = new GameManager();
            return theInstance;
        }
    }
    // player controls
    public GameObject player;

    public int getCurrentWaveNumber()
    {
        return 0;
    }
    // private GameManager()
    // {
    //     // do something

    // }



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {        

    }
   
}
