using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventReferencer : MonoBehaviour
{
    private MoveScript _move;


    private void Start()
    {
        _move = GetComponentInParent<MoveScript>();
    }

    public void CeaseAttack()
    {
        _move.AttackEnded();
    }

    public void StartAttack()
    {
        _move.AttackStarted();
    }
}
