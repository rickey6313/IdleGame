using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    public BoxCollider mCollider;
    private PlayerCtrl owner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetOwner(PlayerCtrl player)
    {
        owner = player;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(PlayerInputManager.instance.playerInputState == PlayerInputState.Attack)
        {
            if (other.CompareTag("monster"))
            {
                try
                {
                    MonsterBase monster = other.GetComponent<MonsterBase>();
                    monster.Damaged(5.0f);
                }
                catch(System.Exception e)
                {
                    Debug.Log(e.Message);
                }
                
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {

    }
}
