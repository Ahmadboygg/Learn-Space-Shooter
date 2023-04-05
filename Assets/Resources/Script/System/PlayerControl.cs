using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour, IDamageable, IHealable
{
    public float movementSpeed = 0f;
    public float shootCoolDown = 0f;
    public GameObject projectileObject = null;
    public Transform projectileSpawn = null;
    public event Action OnGameOverUI;

    MainInputAction inputActions;
    CharacterStatus characterStatus;
    Vector2 moveInput;
    float currentShootCoolDown;
    float maxWidth;
    float maxHeight;
    void Awake()
    {
        inputActions = new MainInputAction();
        inputActions.PlayerControl.Enable();
        inputActions.PlayerControl.Attack.performed += ShootHandle;

        maxWidth = Camera.main.aspect * Camera.main.orthographicSize - 0.5f;
        maxHeight = Camera.main.orthographicSize - 2f;
        characterStatus = GetComponent<CharacterStatus>();
    }

    void Update()
    {
        //Player Move Input
        moveInput = inputActions.PlayerControl.Move.ReadValue<Vector2>();
        MoveHandle();

        //Player Shoot Cool Down
        if(currentShootCoolDown > 0)
        {
            currentShootCoolDown -= Time.deltaTime;
        }
        currentShootCoolDown = Mathf.Clamp(currentShootCoolDown, 0, shootCoolDown);
    }

    void MoveHandle()
    {
        transform.Translate(moveInput *movementSpeed * Time.deltaTime);
        Vector2 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -maxWidth, maxWidth);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -maxHeight, maxHeight);
        transform.position = clampedPosition;
    }

    void ShootHandle(InputAction.CallbackContext context)
    {
        if(context.performed && currentShootCoolDown <= 0)
        {
            Instantiate(projectileObject,projectileSpawn.position,Quaternion.identity);
            currentShootCoolDown = shootCoolDown;
        }
    }

    public void TakeDamage(int damage)
    {
        characterStatus.currentHealth -= damage;
        if(characterStatus.GetHealth() <= 0)
        {
            Destroy(gameObject);
            OnGameOverUI?.Invoke();
        }
    }
    public void TakeDamage(){}
    

    public void HealAmount(int heal)
    {
        characterStatus.currentHealth += heal;
        if(characterStatus.currentHealth >= characterStatus.maxHealth)
        {
            characterStatus.currentHealth = characterStatus.maxHealth;
        }
    }

    
}
