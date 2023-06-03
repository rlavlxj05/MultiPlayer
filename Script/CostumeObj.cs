using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class CostumeObj : NetworkBehaviour
{
    [SerializeField] private Button Bt;

    [SerializeField] private GameObject objectPrefab; // 생성할 객체의 프리팹

    [SerializeField] private Transform target; // 따라야 할 대상 개체

    private GameObject instantiatedObject; // 인스턴스화된 객체에 대한 참조

    void Start()
    {
        Bt.onClick.AddListener(CreateAndFollowObject);
    }

    public void CreateAndFollowObject()
    {
        if (instantiatedObject == null) // 존재하지 않는 경우에만 객체 생성
        {
            instantiatedObject = Instantiate(objectPrefab, transform.position, Quaternion.identity);
            instantiatedObject.GetComponent<NetworkObject>().Spawn(true);
        }
    }

    private void Update()
    {
        if (instantiatedObject != null && target != null) // 개체가 대상을 따르도록 합니다.
        {
            instantiatedObject.transform.position = target.position;
            instantiatedObject.transform.rotation = target.rotation;
        }
    }
}
