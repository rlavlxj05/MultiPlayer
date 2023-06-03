using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private Button serverBth;
    [SerializeField] private Button hostBth;
    [SerializeField] private Button clientBth;

    private void Awake()
    {
        serverBth.onClick.AddListener( () => { NetworkManager.Singleton.StartServer(); });
        hostBth.onClick.AddListener(() => { NetworkManager.Singleton.StartHost(); });
        clientBth.onClick.AddListener(() => { NetworkManager.Singleton.StartClient(); });
    }
}
