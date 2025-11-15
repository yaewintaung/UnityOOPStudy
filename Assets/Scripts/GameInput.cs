using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance;

    public event EventHandler OnAttackClick;
    public event EventHandler OnJumpClick;
    public event EventHandler OnReloadClick;

    public InputSystem_Actions action;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        action = new InputSystem_Actions();
        action.Enable();

        action.Player.Attack.performed += Attack_performed;
        action.Player.Jump.performed += Jump_performed;
        action.Player.Reload.performed += Reload_performed; ;
    }

    private void Reload_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnReloadClick?.Invoke(this,EventArgs.Empty);
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnJumpClick?.Invoke(this, EventArgs.Empty);
    }

    private void Attack_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnAttackClick?.Invoke(this,EventArgs.Empty);
    }

    private void OnDisable()
    {
        action.Disable();
    }

    public Vector2 GetInputVectorNormalized()
    {
        var inputVector = action.Player.Move.ReadValue<Vector2>().normalized;

        return inputVector;
    }
}
