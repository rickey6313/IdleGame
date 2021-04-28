using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterBase : CreatureClass
{
    public Animator animator;
    public Transform targetTransform;
    public NavMeshAgent nvAgent;

    public float traceDist = 15.0f;
    public float attackDist = 10.0f;
    public float attackDuration = 2.0f;
    public float attackTime = 0;

    public bool canAttack = false;
    public bool isDead = false;

    public virtual void Attack(float dmg) { }
    public virtual void Damaged(float dmg) { }
}
