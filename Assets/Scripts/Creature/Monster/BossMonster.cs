using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum BossState
{ 
    IDLE,
    TRACE,
    ATTACK,
    DIE
}


public class BossMonster : MonsterBase
{
    private BossState aniState = BossState.IDLE;

    void Start()
    {
        health = 10;
        mana = 10;
        stamina = 10;
        traceDist = 15.0f;
        attackDist = 2.0f;
        attackTime = 2.0f;

        targetTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = GetComponent<NavMeshAgent>();

        nvAgent.stoppingDistance = attackDist;

        StartCoroutine(CheckState());
        StartCoroutine(CheckStateForAction());
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0 && aniState != BossState.DIE && !isDead)
        {
            animator.SetTrigger("die");
            aniState = BossState.DIE;
            isDead = true;
        }
    }

    IEnumerator CheckState()
    {
        while(!isDead)
        {
            yield return null;

            float dist = Vector3.Distance(targetTransform.position, transform.position);

            if(dist <= attackDist)
            {
                aniState = BossState.ATTACK;
            }
            else if(dist <= traceDist)
            {
                aniState = BossState.TRACE;
            }
            else
            {
                aniState = BossState.IDLE;
            }
        }
    }

    IEnumerator CheckStateForAction()
    {
        while(!isDead)
        {
            switch(aniState)
            {
                case BossState.IDLE:
                    nvAgent.isStopped = true;
                    yield return IdleRoutine();
                    break;
                case BossState.TRACE:                    
                    nvAgent.destination = targetTransform.position;
                    nvAgent.isStopped = false;
                    yield return TraceRoutine();
                    break;
                case BossState.ATTACK:
                    nvAgent.destination = targetTransform.position;
                    //transform.LookAt(targetTransform);
                    yield return AttackRoutine();
                    break;
                case BossState.DIE:
                    break;
            }
            yield return null;
        }
    }

    IEnumerator IdleRoutine()
    {
        animator.SetTrigger("idle");
        while (aniState == BossState.IDLE)
        {
            yield return null;
        }
        animator.ResetTrigger("idle");
    }

    IEnumerator TraceRoutine()
    {
        attackTime = 2.0f;
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            animator.SetTrigger("walk");
        }            
        else
            yield return null;
    }

    IEnumerator AttackRoutine()
    {
        attackTime += Time.deltaTime;

        if(attackTime >= attackDuration)
        {
            attackTime = 0;
            int rand = Random.Range(0, 3);
            switch (rand)
            {
                case 0:
                    if (!animator.GetCurrentAnimatorStateInfo(0).IsName("attack_01"))
                    {
                        animator.SetTrigger("attack_01");
                    }
                    else
                        yield return null;
                    break;
                case 1:
                    if (!animator.GetCurrentAnimatorStateInfo(0).IsName("attack_02"))
                    {
                        animator.SetTrigger("attack_02");
                    }
                    else
                        yield return null;
                    break;
                case 2:
                    if (!animator.GetCurrentAnimatorStateInfo(0).IsName("attack_03"))
                    {
                        animator.SetTrigger("attack_03");
                    }
                    else
                        yield return null;
                    break;
            }
        }
    }

    public override void Damaged(float dmg)
    {
        health -= (int)dmg;
    }

}
