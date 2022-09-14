using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class SplashScreenInput : MonoBehaviour
{
    [Header("Event")]
    [SerializeField] private UnityEvent onClick;
    
    private bool _inputHappened = false;

    private void Awake()
    {
#if UNITY_WEBGL
        // print("Platform: WEBGL");
        return;
#elif UNITY_EDITOR
        // print("Platoform: EDITOR");
        return;
#else
        DeactivateGameObject();
#endif
    }

    // Start is called before the first frame update
    void Start()
    {
        // var myAction = new InputAction(binding: "/*/<button>");
        // myAction.performed += _ => RespondToInput();
        // myAction.Enable();
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            RespondToInput();
        }
    }

    public void RespondToInput()
    {
        if (!_inputHappened)
        {
            onClick?.Invoke();
            _inputHappened = true;
        }
    }

    private void DeactivateGameObject()
    {
        this.gameObject.SetActive(false);
    }
}
