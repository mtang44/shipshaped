using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.ComponentModel;
using Unity.VisualScripting;

public class ShipController : MonoBehaviour
{
  
    [SerializeField]
     public GameObject GroundPlayer;
    public int containerCount;

    public  GameObject ContainerHolder;
    [SerializeField]
    private GameObject canvasBackground;
    [SerializeField]
    private GameObject playerScore;
    [SerializeField]
    private GameObject inGameScore;
   
   [SerializeField]
    private GameObject buttonGameObject;
    private Button nextButton;
    private int playerDeaths;
    private int playerNum;


    void Start()
    {
        containerCount = 0;
        nextButton = buttonGameObject.GetComponent<Button>();
        canvasBackground.SetActive(false);

        playerDeaths = 0;
        playerNum = 1;

        nextButton.onClick.AddListener(() =>
        {
            canvasBackground.SetActive(false);
            inGameScore.GetComponent<TimerManager>().totalTime = 0f;
            inGameScore.SetActive(true);
        });

    }

    // Update is called once per frame
    void Update()
    {
        if (GroundPlayer.activeInHierarchy == false)
        {
            
            clearScene();
            displayScore();
            GroundPlayer.SetActive(true);
        }

    }
    public void clearScene()
    {
        Transform parent = ContainerHolder.transform;

        for (int i = parent.childCount - 1; i >= 0; i--)
        {
            Debug.Log("Clearing scene");
            Destroy(parent.GetChild(i).gameObject);
        }
    }
    void displayScore()
    {
        playerDeaths++;
        if (playerDeaths % 2 != 0)
        {
            playerNum = 1;
        }
        else
        {
            playerNum = 2;
        }
        canvasBackground.SetActive(true);
        inGameScore.SetActive(false);
        playerScore.GetComponent<TextMeshProUGUI>().text = "Player " + playerNum + " score: "+ inGameScore.GetComponent<TimerManager>().DisplayTime(inGameScore.GetComponent<TimerManager>().totalTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            ContainerController triggerContainer = other.GetComponent<ContainerController>();
            if (!triggerContainer.getOnShip())
            {
                triggerContainer.setOnShip(true);
            }
            else Debug.Log("container already on ship");
        }
    }
}
