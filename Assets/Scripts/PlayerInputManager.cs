using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public enum PlayerInputState
{    
    IDLE,
    FORWARD,
    Left,
    Right,
    BACK,
    Run,
    Attack
}

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager instance;
    public bool canReceiveInput;
    public bool inputReceived;

    public PlayerInputState playerInputState = PlayerInputState.IDLE;
    public int action = 0;
    public int actionNum = 0;
    public float currentInputComboTime;
    public float nextInputComboTime;
    public float walkSpeed = 6.0f;
    public float runSpeed = 12.0f;
    public float aniSpeedScale = 1.5f;
    private PlayerCtrl playerctrl;
    private Animator animator;
    private Transform playerTransform;

    private WaitForEndOfFrame eof = new WaitForEndOfFrame();

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform;
    }

    public void Init(PlayerCtrl player, Animator _animator)
    {
        playerctrl = player;
        animator = _animator;

        //StartCoroutine(ProcessRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        //CheckInput();
        //Attack();
    }

    private void FixedUpdate()
    {
            
    }

    public void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canReceiveInput)
            {
                
                inputReceived = true;
                canReceiveInput = false;
            }
            else
            {
                return;
            }
        }
    }

    public void InputManager()
    {
        if(!canReceiveInput)
        {
            canReceiveInput = true;
        }
        else
        {
            canReceiveInput = false;
        }
    }
    public void AnimatorRebind()
    {
        animator.Rebind();
        
    }
    private IEnumerator ProcessRoutine()
    {   
        while(true)
        {
            
            switch (playerInputState)
            {
                case PlayerInputState.IDLE:
                    
                    yield return StartCoroutine(IdleRoutine());
                    break;
                case PlayerInputState.FORWARD:
                    yield return StartCoroutine(WalkRoutine());
                    break;
                case PlayerInputState.Left:
                    yield return StartCoroutine(LeftRoutine());
                    break;
                case PlayerInputState.Right:
                    yield return StartCoroutine(RightRoutine());
                    break;
                case PlayerInputState.BACK:
                    yield return StartCoroutine(BackRoutine());
                    break;
                case PlayerInputState.Run:
                    yield return StartCoroutine(RunRoutine());
                    break;
                case PlayerInputState.Attack:
                    yield return StartCoroutine(AttackRoutine());
                    break;
            }
            yield return eof;
        }
    }
    private void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetInputState(PlayerInputState.Attack);
        }
        if (Input.GetKey(KeyCode.W))
        {
            if(Input.GetKey(KeyCode.LeftShift))
                SetInputState(PlayerInputState.Run);
            else
                SetInputState(PlayerInputState.FORWARD);
        }
        else if ((Input.GetKey(KeyCode.A)))
        {
            SetInputState(PlayerInputState.Left);
        }
        else if ((Input.GetKey(KeyCode.D)))
        {
            SetInputState(PlayerInputState.Right);
        }
        else if ((Input.GetKey(KeyCode.S)))
        {
            SetInputState(PlayerInputState.BACK);
        }
        else
        {
            if (GetInputState() == PlayerInputState.IDLE || GetInputState() == PlayerInputState.Attack)
                return;
            SetInputState(PlayerInputState.IDLE);
        }
    }

    private PlayerInputState GetInputState()
    {
        return playerInputState;
    }

    private void SetInputState(PlayerInputState state)
    {
        playerInputState = state;
    }

    private IEnumerator IdleRoutine()
    {        
        animator.SetTrigger("Idle");
        while (GetInputState() == PlayerInputState.IDLE)
        {            
            yield return null;
        }
        animator.ResetTrigger("Idle");
    }
    private IEnumerator LeftRoutine()
    {
        animator.SetTrigger("Left");
        while (GetInputState() == PlayerInputState.Left)
        {
            yield return null;
        }
    }
    private IEnumerator RightRoutine()
    {
        animator.SetTrigger("Right");
        while (GetInputState() == PlayerInputState.Right)
        {
            yield return null;
        }        
    }

    private IEnumerator WalkRoutine()
    {        
        playerctrl.speed = walkSpeed;
        animator.speed = 1;
        animator.SetTrigger("Walk");
        while (GetInputState() == PlayerInputState.FORWARD)
        {
            yield return null;
        }
    }
    private IEnumerator BackRoutine()
    {
        animator.SetTrigger("Back");
        while (GetInputState() == PlayerInputState.BACK)
        {
            yield return null;
        }
        animator.ResetTrigger("Back");
    }
    private IEnumerator RunRoutine()
    {
        playerctrl.speed = runSpeed;
        animator.speed = aniSpeedScale;

        animator.SetTrigger("Run");
        while (GetInputState() == PlayerInputState.Run)
        {
            yield return null;
        }
        playerctrl.speed = walkSpeed;
        animator.speed = 1;
    }

    private IEnumerator AttackRoutine()
    {
        //Debug.Log("AttackRoutine action");

        action = 1;
        actionNum = 0;
        inputReceived = false;
        animator.SetInteger("Action", action);
        animator.SetInteger("ActionNum", actionNum);
        animator.SetTrigger("Trigger");
        while (GetInputState() == PlayerInputState.Attack)
        {
            yield return null;
        }
    }
}
