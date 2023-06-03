using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
public class NetObj : NetworkBehaviour
{
    public Button Bt;
    public GameObject Obj;

    void Start()
    {
           Bt.onClick.AddListener(CreateObjectOnClick);
    }
    public void CreateObjectOnClick()
    {
        GameObject go = Instantiate(Obj, Vector3.zero, Quaternion.identity);
        go.GetComponent<NetworkObject>().Spawn();  
    }

}
