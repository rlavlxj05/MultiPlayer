using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour
{
    public static PlayerController Instance { get; private set; }

    private bool isWalking;

    private float speed = 3f;
    Rigidbody rigid;
    public Joystick2 joystick;
    Vector3 moveVec;

    private void Start()
    {
        joystick = GameObject.Find("joyBg").GetComponent<Joystick2>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!IsOwner) { return; }
        if (!IsLocalPlayer) { return; }

            float x = joystick.Horizontal();
            float z = joystick.Vertical();

            moveVec = new Vector3(x, 0f, z) * speed * Time.deltaTime;
            rigid.MovePosition(rigid.position + moveVec);

            if (moveVec.sqrMagnitude == 0)
                return;

            Quaternion dirQuat = Quaternion.LookRotation(moveVec);
            Quaternion moveQuat = Quaternion.Slerp(rigid.rotation, dirQuat, 0.3f);
            rigid.MoveRotation(moveQuat);
            isWalking = moveVec != Vector3.zero;
    }

    public bool IsWalking()
    {
        return isWalking;
    }

}