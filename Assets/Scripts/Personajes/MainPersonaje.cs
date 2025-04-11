using UnityEngine;

public abstract class MainPersonaje : MonoBehaviour
{
    protected Animator _animator { get; private set; }

    protected virtual void Awake()
    {
        _animator = this.GetComponent<Animator>();
        if (_animator == null)
        {
            Debug.LogWarning($"{name} no tiene un Animator asignado.");
        }
    }

    public Animator Animator => _animator;

    public void DesactivarAnimator()
    {
        _animator.enabled = false;
    }
}
