using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class UIAni : NetworkBehaviour
{
    private const string IS_UI = "UI";

    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnButtonClick1()
    {
        if (!IsOwner) { return; }
        animator.SetBool(IS_UI, true);
    }
    public void OnButtonClick2()
    {
        if (!IsOwner){return;}
        animator.SetBool(IS_UI, false);
    }
}
