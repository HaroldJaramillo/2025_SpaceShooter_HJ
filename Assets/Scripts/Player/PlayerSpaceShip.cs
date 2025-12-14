using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpaceShip : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float maxSpeed = 100f;
    [SerializeField] float acceleration = 300f;

    [Header("Shooting")]
    [SerializeField] GameObject projectilePrefab;

    [Header("Controls")]
    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference shoot;

    private void OnEnable()
    {
        move.action.started += OnMove;
        move.action.performed += OnMove;
        move.action.canceled += OnMove;

        shoot.action.started += OnShoot;

        move.action.Enable();
        shoot.action.Enable();
    }

    Vector2 currentVelocity = Vector2.zero;
    const float rawMoveThresholdForBraking = 0.1f;

    void Update()
    {
        if (rawMove.magnitude < rawMoveThresholdForBraking)
        {
            currentVelocity *= 0.1f * Time.deltaTime; 
        }
        currentVelocity += rawMove * acceleration * Time.deltaTime;
        float linearVelocity = currentVelocity.magnitude;
        linearVelocity = Mathf.Clamp(linearVelocity, 0, maxSpeed);
        currentVelocity = currentVelocity.normalized * linearVelocity;
        transform.Translate(currentVelocity * Time.deltaTime);
    }

    private void OnDisable()
    {
        move.action.started -= OnMove;
        move.action.performed -= OnMove;
        move.action.canceled -= OnMove;

        shoot.action.started -= OnShoot;

        move.action.Disable();
        shoot.action.Disable();
    }

    Vector2 rawMove;
        private void OnMove(InputAction.CallbackContext obj)
    {
        rawMove = obj.ReadValue<Vector2>();
    }
    private void OnShoot(InputAction.CallbackContext obj)
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        
    }

    

}
