using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerMove : NetworkBehaviour
{
    private bool isWalking;

    // Update is called once per frame
    private void Update()
    {
        if (!IsOwner) return;

        Vector3 move = new Vector3(0, 0, 0);
        float moveSpeed = 3f;

        if (Input.GetKey(KeyCode.W)) move.z = +1f;
        if (Input.GetKey(KeyCode.S)) move.z = -1f;
        if (Input.GetKey(KeyCode.A)) move.x = -1f;
        if (Input.GetKey(KeyCode.D)) move.x = +1f;

        transform.position += move * moveSpeed * Time.deltaTime;
        transform.LookAt(transform.position + move);
        isWalking = move != Vector3.zero;

    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
