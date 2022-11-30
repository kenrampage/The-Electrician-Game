using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Keeps child object position in place instead of moving with parent object
public class ConstrainChildObjectTransform : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool _constrainPosition;

    private Transform _parent;
    private Transform _transform;

    private void Awake()
    {
        _parent = transform.parent;
        _transform = transform;
    }

    private void ConstrainPosition()
    {
        _transform.localPosition = _parent.transform.localPosition * -1;
    }

    private void Update()
    {
        if(_constrainPosition)
        {
            ConstrainPosition();
        }
    }
}
