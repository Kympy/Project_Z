using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    private Rigidbody _Rigidbody = null;
    public Rigidbody GetRigidbody()
    {
        if (_Rigidbody != null)
        {
            return _Rigidbody;
        }
        return null;
    }
    private Animator _Animator = null;
    public Animator GetAnimator()
    {
        if (_Animator != null)
        {
            return _Animator;
        }
        return null;
    }
    public void InitRigidbody()
    {
        if (TryGetComponent<Rigidbody>(out Rigidbody _rigid))
        {
            _Rigidbody = _rigid;
        }
    }
    public void InitAnimator()
    {
        if (TryGetComponent<Animator>(out Animator _animator))
        {
            _Animator = _animator;
        }
    }
}
