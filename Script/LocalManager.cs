using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.Netcode;
using UnityEngine.UI;
public class LocalManager : NetworkBehaviour
{
    public Camera cam;
    public GameObject Jst;
    public GameObject costum_Out;
    public GameObject costum_In;

    void Start()
    {
        if (IsLocalPlayer) return;

        cam.enabled = false;
        Jst.SetActive(false);
        costum_Out.SetActive(false);
        costum_In.SetActive(false);
    }
}
