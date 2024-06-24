using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator animator;
    int hashAtteck = Animator.StringToHash("AttackCount");


    private void Start()
    {
       // animator = GetComponent<Animator>();

        TryGetComponent(out animator);
    }

    public int AttackCount
    {
        get => animator.GetInteger(hashAtteck);
        set => animator.SetInteger(hashAtteck, value);
    }


}
