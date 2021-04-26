using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Monster_Skeleton : MonsterBase
{
    private MonsterSpawner spanwer;
    public enum AniState
    {
        IDLE,
        WATCH,
        TRACE,
        ATTACK,
        DIE
    }

    private AniState aniState = AniState.IDLE;
    private float watchDist;

    private bool m_bDethAniEnd = false;

    public void SetMonsterSpawner(MonsterSpawner inputSpanwer)
    {
        spanwer = inputSpanwer;
    }

    public void Init()
    {
        //Debug.Log("Monster_Skeleton::Init");
        health = 10;
        mana = 10;
        stamina = 10;
        watchDist = 12.0f;
        traceDist = 7.5f;
        attackDist = 3.0f;
        attackTime = 2.0f;
        aniState = AniState.IDLE;
        isDead = false;
        m_bDethAniEnd = false;

        _transform = GetComponent<Transform>();
        targetTransform = GameObject.FindWithTag("Player")?.GetComponent<Transform>() ?? null;
        nvAgent = GetComponent<NavMeshAgent>();

        nvAgent.stoppingDistance = attackDist;

        gameObject.SetActive(true);

        StartCoroutine(CheckState());
        StartCoroutine(CheckStateForAction());
    }

    IEnumerator CheckState()
    {
        while (!isDead)
        {
            yield return null;

            if(health <= 0 && aniState != AniState.DIE && !isDead)
            {
                aniState = AniState.DIE;
                yield break;
            }

            while(targetTransform == null)
                yield return null;

            float dist = Vector3.Distance(targetTransform.position, transform.position);

            if (dist <= attackDist)
            {
                aniState = AniState.ATTACK;
            }
            else if (dist <= watchDist && dist > traceDist)
            {
                aniState = AniState.WATCH;
            }
            else if (dist <= traceDist)
            {
                aniState = AniState.TRACE;
            }
            else
            {
                aniState = AniState.IDLE;
            }
        }
    }

    IEnumerator CheckStateForAction()
    {
        while (!isDead)
        {
            switch (aniState)
            {
                case AniState.IDLE:
                    nvAgent.isStopped = true;
                    yield return IdleRoutine();
                    break;
                case AniState.WATCH:
                    nvAgent.isStopped = true;
                    yield return WatchRoutine();
                    break;
                case AniState.TRACE:
                    nvAgent.destination = targetTransform.position;
                    nvAgent.isStopped = false;
                    yield return TraceRoutine();
                    break;
                case AniState.ATTACK:
                    nvAgent.destination = targetTransform.position;
                    //transform.LookAt(targetTransform);
                    yield return AttackRoutine();
                    break;
                case AniState.DIE:
                    yield return DieRoutine();
                    
                    break;
            }
            yield return null;
        }
    }

    IEnumerator IdleRoutine()
    {
        animator.SetTrigger("idle");
        while (aniState == AniState.IDLE)
        {
            yield return null;
        }
        animator.ResetTrigger("idle");
    }
    IEnumerator WatchRoutine()
    {
        animator.SetTrigger("watch");
        while (aniState == AniState.WATCH)
        {
            yield return null;
        }
        animator.ResetTrigger("watch");
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

        if (attackTime >= attackDuration)
        {
            attackTime = 0;
            animator.SetTrigger("attack");
        }
        yield return null;
    }

    IEnumerator DieRoutine()
    {
        Debug.Log("DieRoutine 1");

        isDead = true;
        animator.SetTrigger("die");
        
        while (!m_bDethAniEnd)
        {
            yield return null;
        }

        StopAllCoroutines();
        gameObject.SetActive(false);
        spanwer.HideTarget(gameObject);
        Debug.Log("DieRoutine 3");
    }

    public void DieEventFromAnimationEvent()
    {
        Debug.Log("DieEvent");
        m_bDethAniEnd = true;
    }


    public override void Damaged(float dmg)
    {
        health -= (int)dmg;
    }

}
