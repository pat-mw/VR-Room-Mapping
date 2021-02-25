using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class HandController : MonoBehaviour
{

    [SerializeField] InputActionReference gripAction;

    [SerializeField] InputActionReference triggerAction;

    private Animator handAnimator;

    private void Awake()
    {
        gripAction.action.performed += GripPress;
        triggerAction.action.performed += TriggerPress;
        handAnimator = GetComponent<Animator>();
    }

    private void TriggerPress(InputAction.CallbackContext obj) => handAnimator.SetFloat("Trigger", obj.ReadValue<float>());
    private void GripPress(InputAction.CallbackContext obj) => handAnimator.SetFloat("Grip", obj.ReadValue<float>());
}
