using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine.Networking;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private Button serverButton;
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;
    [SerializeField] private GameObject cranePrefab;
    [SerializeField] private GameObject playerPrefab;
    NetworkManager networkManager;


    private void OnClientConnectedCallback(ulong clientID)
    {
        if (networkManager.LocalClientId == clientID)
        {
            GameObject playerPrefabTransform = Instantiate(playerPrefab);
            playerPrefabTransform.GetComponent<NetworkObject>().Spawn(true);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        networkManager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        networkManager.OnClientConnectedCallback += OnClientConnectedCallback;
        ulong clientId = networkManager.LocalClientId;
        serverButton.onClick.AddListener(() =>
        {
            networkManager.StartServer();
        });

        hostButton.onClick.AddListener(() =>
        {
            networkManager.StartHost();
            GameObject cranePrefabTransform = Instantiate(cranePrefab);
            cranePrefabTransform.GetComponent<NetworkObject>().Spawn(true);

        });

        clientButton.onClick.AddListener(() =>
        {
            networkManager.StartClient();
            //OnClientConnectedCallback(clientId);


        });
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
