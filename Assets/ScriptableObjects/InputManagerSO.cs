using System;
using Unity.Android.Gradle.Manifest;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "InputManager")]
public class InputManagerSO : ScriptableObject
{
    Controles misControles;
    public event System.Action OnSaltar;
    public event Action<Vector2> OnMover;
    public event System.Action OnAtacar;
    private void OnEnable()
    {
        misControles = new Controles();
        misControles.Gameplay.Enable();
        misControles.Gameplay.Saltar.started += Saltar;
        misControles.Gameplay.Mover.performed += Mover;
        misControles.Gameplay.Mover.canceled += Mover;

        misControles.Gameplay.Atacar.started += Atacar;
    }

    private void Atacar(InputAction.CallbackContext obj)
    {
        OnAtacar?.Invoke();
    }

    private void Mover(InputAction.CallbackContext ctx)
    {
        OnMover?.Invoke(ctx.ReadValue<Vector2>());
    }

    private void Saltar(InputAction.CallbackContext ctx)
    {
        OnSaltar?.Invoke(); //Disparamos el evento de que se ha producido un salto
    }

    private void OnDisable()
    {
        misControles.Gameplay.Disable();
    }
}
