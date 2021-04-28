using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using RPGCharacterAnimsFREE;


public class PlayerCtrl : CreatureClass
{    
    public MouseRotate mouseRotate;
    public Camera playerCamera;
    public Animator playerAnimator;
    public PlayerInputManager playerInputManager;
    public AttackCollider atCollider;

    public float speed;
    public float jumpSpeed;
    public float gravity;

    private CharacterController playerCtrl;
    private Vector3 moveDir;

    public float mouseRotationSpeed;
    private Quaternion lookRotation;
    private Vector3 mouseDirection;

    private Inventory inventory;
    [SerializeField]
    private UI_Inventory uiInventory;

    void Start()
    {
        DontDestroyOnLoad(this);

        health = 100;
        mana = 100;
        stamina = 100;

        mouseRotationSpeed = 5.0f;
        speed = 6.0f;
        jumpSpeed = 8.0f;
        gravity = 20.0f;

        moveDir = Vector3.zero;
        playerCtrl = GetComponent<CharacterController>();
        //mouseRotate.Init(transform, playerCamera.transform);

        //playerInputManager.Init(this, playerAnimator);

        //playerAnimator.gameObject.AddComponent<RPGCharacterAnimatorEvents>();
        //playerAnimator.updateMode = AnimatorUpdateMode.AnimatePhysics;
        //playerAnimator.cullingMode = AnimatorCullingMode.CullUpdateTransforms;

        inventory = new Inventory();
        inventory.AddItem(ItemFactory.SpawnConsumption("Potion_0"));
        inventory.AddItem(ItemFactory.SpawnConsumption("Potion_1"));
        inventory.AddItem(ItemFactory.SpawnEquipment("Equip_0"));
        inventory.AddItem(ItemFactory.SpawnEquipment("Equip_1"));
        inventory.AddItem(ItemFactory.SpawnEquipment("Equip_2"));
        //inventory.AddItem(ItemDataBase.FindExpandableItem(0));
        uiInventory.SetInventory(inventory);
        ItemPropertyModifier.CreatePrefix(inventory.GetItems()[2]);
    }

    // Update is called once per frame
    void Update()
    {
        //RotateView();
        //Move();
    }

    private void FixedUpdate()
    {
        //mouseRotate.UpdateCursorLock();
    }

    private void RotateView()
    {
        //mouseRotate.LookRotation(transform, playerCamera.transform);
    }
    private void Move()
    {
        if (playerCtrl.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);

            moveDir *= speed;

            if (Input.GetButton("Jump"))
                moveDir.y = jumpSpeed;
        }

        moveDir.y -= gravity * Time.deltaTime;

        playerCtrl.Move(moveDir * Time.deltaTime);
    }
}
