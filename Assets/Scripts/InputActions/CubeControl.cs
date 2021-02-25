// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputActions/CubeControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CubeControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CubeControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CubeControl"",
    ""maps"": [
        {
            ""name"": ""CubeController"",
            ""id"": ""e007542b-4b22-44a0-81f0-fc1261497ef2"",
            ""actions"": [
                {
                    ""name"": ""MoveCube"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e5c17e1f-9609-44b4-a3be-cc71da8a4ea7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""09100dd8-b62d-4dda-9ee4-d1434989c2de"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseClick"",
                    ""type"": ""Button"",
                    ""id"": ""997a84be-5d3b-4635-b124-7e74795b28f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""6328ca0e-d1bb-4181-87b8-b38d4e141072"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCube"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4ee19d05-3df8-47a7-85a0-22ecbfde38ad"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCube"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5134c3b9-a764-4c35-8f48-20f0c1be545f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCube"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""94e9de46-4064-4bb5-bb45-7507740f1d88"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCube"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a073d366-b696-4bd9-be57-13a1fff152dd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCube"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7e87da01-5e0c-46c8-bb75-6322d33ce31b"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a75ebaa-cf35-4e6f-876e-589ae7fdb65b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CubeController
        m_CubeController = asset.FindActionMap("CubeController", throwIfNotFound: true);
        m_CubeController_MoveCube = m_CubeController.FindAction("MoveCube", throwIfNotFound: true);
        m_CubeController_MousePosition = m_CubeController.FindAction("MousePosition", throwIfNotFound: true);
        m_CubeController_MouseClick = m_CubeController.FindAction("MouseClick", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // CubeController
    private readonly InputActionMap m_CubeController;
    private ICubeControllerActions m_CubeControllerActionsCallbackInterface;
    private readonly InputAction m_CubeController_MoveCube;
    private readonly InputAction m_CubeController_MousePosition;
    private readonly InputAction m_CubeController_MouseClick;
    public struct CubeControllerActions
    {
        private @CubeControl m_Wrapper;
        public CubeControllerActions(@CubeControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveCube => m_Wrapper.m_CubeController_MoveCube;
        public InputAction @MousePosition => m_Wrapper.m_CubeController_MousePosition;
        public InputAction @MouseClick => m_Wrapper.m_CubeController_MouseClick;
        public InputActionMap Get() { return m_Wrapper.m_CubeController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CubeControllerActions set) { return set.Get(); }
        public void SetCallbacks(ICubeControllerActions instance)
        {
            if (m_Wrapper.m_CubeControllerActionsCallbackInterface != null)
            {
                @MoveCube.started -= m_Wrapper.m_CubeControllerActionsCallbackInterface.OnMoveCube;
                @MoveCube.performed -= m_Wrapper.m_CubeControllerActionsCallbackInterface.OnMoveCube;
                @MoveCube.canceled -= m_Wrapper.m_CubeControllerActionsCallbackInterface.OnMoveCube;
                @MousePosition.started -= m_Wrapper.m_CubeControllerActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_CubeControllerActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_CubeControllerActionsCallbackInterface.OnMousePosition;
                @MouseClick.started -= m_Wrapper.m_CubeControllerActionsCallbackInterface.OnMouseClick;
                @MouseClick.performed -= m_Wrapper.m_CubeControllerActionsCallbackInterface.OnMouseClick;
                @MouseClick.canceled -= m_Wrapper.m_CubeControllerActionsCallbackInterface.OnMouseClick;
            }
            m_Wrapper.m_CubeControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveCube.started += instance.OnMoveCube;
                @MoveCube.performed += instance.OnMoveCube;
                @MoveCube.canceled += instance.OnMoveCube;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @MouseClick.started += instance.OnMouseClick;
                @MouseClick.performed += instance.OnMouseClick;
                @MouseClick.canceled += instance.OnMouseClick;
            }
        }
    }
    public CubeControllerActions @CubeController => new CubeControllerActions(this);
    public interface ICubeControllerActions
    {
        void OnMoveCube(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnMouseClick(InputAction.CallbackContext context);
    }
}
