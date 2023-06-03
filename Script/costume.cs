using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine.Networking;
using Unity.Networking;

public class costume : NetworkBehaviour
{
    [SerializeField] private Button[] btns;
    [SerializeField] private List<GameObject> GameOj;
    GameObject Equaipcostume;

    private void Start()
    {
        if (IsLocalPlayer)
        {
            for (int i = 0; i < this.btns.Length; i++)
            {
                
                int costumeIndex = i;
                btns[costumeIndex].onClick.AddListener(() => this.TaskOnClick(costumeIndex));
            }
        }
    }

    private void TaskOnClick(int costumeIndex)
    {
        if (IsLocalPlayer) {
            if (Equaipcostume != null)
                Equaipcostume.SetActive(false);
            Equaipcostume = GameOj[costumeIndex];
            Equaipcostume.SetActive(true);
        }
    }

}
