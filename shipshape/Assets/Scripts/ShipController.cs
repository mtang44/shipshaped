using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    public List<GameObject> inventory;
    public int containerCount;
    private GameObject canvasBackground;
    private GameObject playerScore;
    private GameObject inGameScore;
    private GameObject player;
    private GameObject buttonGameObject;
    private Button nextButton;
    private int playerDeaths;
    private int playerNum;


    void Start()
    {
        containerCount = 0;
        inventory = new List<GameObject>();
        canvasBackground = GameObject.Find("Canvas (1)canvasBackground");
        playerScore = GameObject.Find("Canvas (1)/roundOver");
        inGameScore = GameObject.Find("Canvas (1)/Player 1 TimerText");
        buttonGameObject = GameObject.Find("Canvas (1)/Button");
        nextButton = buttonGameObject.GetComponent<Button>();
        player = GameObject.Find("GroundPlayer");
        playerScore.SetActive(false);
        canvasBackground.SetActive(false);
        buttonGameObject.SetActive(false);

        playerDeaths = 0;
        playerNum = 1;

        nextButton.onClick.AddListener(() =>
        {
            playerScore.SetActive(false);
            canvasBackground.SetActive(false);
            inGameScore.GetComponent<TimerManager>().totalTime = 0f;
            inGameScore.SetActive(true);
            buttonGameObject.SetActive(false);
        });

    }

    // Update is called once per frame
    void Update()
    {
        if (player.activeSelf == false)
        {
            player.SetActive(true);
            displayScore();
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
        playerScore.SetActive(true);
        inGameScore.SetActive(false);
        playerScore.GetComponent<TextMeshProUGUI>().text = "Player " + playerNum + "score: "+ inGameScore.GetComponent<TimerManager>().DisplayTime(inGameScore.GetComponent<TimerManager>().totalTime);
        buttonGameObject.SetActive(true);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            
            ContainerController triggerContainer = other.GetComponent<ContainerController>();
            if (!triggerContainer.getOnShip())
            {
                 Debug.Log("container added to ship ");
                containerCount += 1;
                Debug.Log("# of container = " + containerCount);
                Debug.Log("onShip set to true");
                triggerContainer.setOnShip(true);
            }
            else Debug.Log("container already on ship");
        }
    }
    // void OnTriggerExit(Collider other)
    // {
    //     Debug.Log("ship detected exit collision");

    //     if (other.gameObject.layer == 3)
    //     {
    //         ContainerController currentContainerScript = other.GetComponentInParent<ContainerController>();
    //         if (currentContainerScript.getOnShip())
    //         {
    //             currentContainerScript.setOnShip(false);
    //             inventory.Remove(other.gameObject);

    //             Debug.Log("container was removed");
    //             Debug.Log("onShip set to false");
    //             containerCount -= 1;
    //             Debug.Log("# of containers = " + containerCount);
    //         }
    //     }
   // }

public void checkShipBalance()
    {

    }
}
