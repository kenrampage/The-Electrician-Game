using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FirstPersonController))]
public class PlayerFootsteps : MonoBehaviour
{
    private Vector3 _lastStepPos;
    private float _distanceFromLastStep;

    private Vector2 _lastInput;
    private float _differenceFromLastInput;

    [Header("Settings")]
    [SerializeField] private float _stepInterval;
    [SerializeField] private float _directionChangeThreshold = .5f;
    [SerializeField] private bool _stepsOn;

    [Header("References")]
    private FirstPersonController _firstPersonController;
    private InputManager _inputManager;

    [Header("Audio")]
    [SerializeField] private FMODPlayOneShot _sfxStepCarpet;
    [SerializeField] private FMODPlayOneShot _sfxStepCarpetStartEnd;

    private void Awake()
    {
        _firstPersonController = GetComponent<FirstPersonController>();
        _inputManager = InputManager.Instance;
    }

    private void Start()
    {
        InitializeSteps();
    }

    private void Update()
    {
        if (_stepsOn)
        {
            if (_firstPersonController.GetGroundedStatus())
            {
                CheckInputDirectionChanges();
                CheckDistanceFromLastStep();
            }
        }
    }

    // Calculates difference between player inputs from last frame to this frame and triggers handlestepstartend function when threshold is met
    private void CheckInputDirectionChanges()
    {
        _differenceFromLastInput = Vector3.Distance(_inputManager.MoveInput, _lastInput);
        _lastInput = _inputManager.MoveInput;

        if (_differenceFromLastInput >= _directionChangeThreshold && _lastInput != new Vector2(0, 0))
        {
            HandleStepStartEnd();
        }
    }


    // Calculates distance between steps and triggers handlestep function when the stepinterval is met
    private void CheckDistanceFromLastStep()
    {
        _distanceFromLastStep += Vector3.Distance(transform.position, _lastStepPos);

        _lastStepPos = transform.position;

        if (_distanceFromLastStep >= _stepInterval)
        {
            HandleStep();
        }
    }

    private void RestartSteps()
    {
        _differenceFromLastInput = 0f;
        _distanceFromLastStep = 0f;
        
    }

    private void InitializeSteps()
    {
        _differenceFromLastInput = 0f;
        _distanceFromLastStep = 0f;
        _lastStepPos = transform.position;
        _lastInput = new Vector2(0, 0);
    }

    private void HandleStep()
    {
        RestartSteps();
        _sfxStepCarpet.Play();
    }

    private void HandleStepStartEnd()
    {
        RestartSteps();
        _sfxStepCarpetStartEnd.Play();
    }

    public void TurnStepsOn()
    {
        RestartSteps();
        _stepsOn = true;
    }

    public void TurnStepsOff()
    {
        RestartSteps();
        _stepsOn = false;
    }

}
