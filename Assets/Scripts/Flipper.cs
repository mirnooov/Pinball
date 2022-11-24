using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Flipper : MonoBehaviour
{
    private Animator _animator;
    private readonly int _pressedAnimatorTrigger = Animator.StringToHash("Pressed");
    private bool _isPressed;

    public bool IsPressed => _isPressed;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        _animator.SetTrigger(_pressedAnimatorTrigger);
        _isPressed = true;
    }

    private void OnMouseUp()
    {
        _animator.ResetTrigger(_pressedAnimatorTrigger);
        _isPressed = false;
    }
}