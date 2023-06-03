using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class CostumeObj : NetworkBehaviour
{
    [SerializeField] private Button Bt;

    [SerializeField] private GameObject objectPrefab; // ������ ��ü�� ������

    [SerializeField] private Transform target; // ����� �� ��� ��ü

    private GameObject instantiatedObject; // �ν��Ͻ�ȭ�� ��ü�� ���� ����

    void Start()
    {
        Bt.onClick.AddListener(CreateAndFollowObject);
    }

    public void CreateAndFollowObject()
    {
        if (instantiatedObject == null) // �������� �ʴ� ��쿡�� ��ü ����
        {
            instantiatedObject = Instantiate(objectPrefab, transform.position, Quaternion.identity);
            instantiatedObject.GetComponent<NetworkObject>().Spawn(true);
        }
    }

    private void Update()
    {
        if (instantiatedObject != null && target != null) // ��ü�� ����� �������� �մϴ�.
        {
            instantiatedObject.transform.position = target.position;
            instantiatedObject.transform.rotation = target.rotation;
        }
    }
}
