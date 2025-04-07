using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventReferencer : MonoBehaviour
{
    private MoveScript _move;
    private HitManager _hit;

    private void Start()
    {
        _move = GetComponentInParent<MoveScript>();
        _hit = GetComponentInParent<HitManager>();
    }

    public void CeaseAttack()
    {
        _move.AttackEnded();
    }

    public void StartAttack()
    {
        _move.AttackStarted();
    }

    public void Buff()
    {
        _move.Buffer();
    }

    public void IsLaunched()
    {
        _move.invulnerable = true;
        _move.isLaunched = true;
        _hit.isStunned = true;
        //_move.LaunchManager();
    }

    public void LaunchedEnded()
    {
        
        _move.isLaunched = false;
        _hit.isStunned = false;
             
        _move.invulnerable = false;
        _hit.stunTime = 0;
        
    }
}
