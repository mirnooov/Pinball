using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Flipper : MonoBehaviour
{
    [SerializeField] private InputButton _inputButton;
    
    private Animator _animator;
    private readonly int _pressedAnimatorTrigger = Animator.StringToHash("Pressed");
    private bool _isPressed;

    public bool IsPressed => _isPressed;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _inputButton.MouseDown += Active;
        _inputButton.MouseUp += UnActive;
    }
    
    private void OnDisable()
    {
        _inputButton.MouseDown -= Active;
        _inputButton.MouseUp -= UnActive;
    }

    private void Active()
    {
        _animator.SetTrigger(_pressedAnimatorTrigger);
        _isPressed = true;
    }

    private void UnActive()
    {
        _animator.ResetTrigger(_pressedAnimatorTrigger);
        _isPressed = false;
    }
}