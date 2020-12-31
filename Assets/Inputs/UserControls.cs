// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/UserControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @UserControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @UserControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""UserControls"",
    ""maps"": [
        {
            ""name"": ""UserAction"",
            ""id"": ""4123171f-66b5-4064-b26b-092ee3570167"",
            ""actions"": [
                {
                    ""name"": ""LeftMouseClick"",
                    ""type"": ""Button"",
                    ""id"": ""669c27c5-1e07-4813-8267-222874bdfe44"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""b5c7802b-d150-412d-9b86-c86bc1450c00"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0c871382-854f-48b9-90fa-8ba93b1af0cd"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftMouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8281df2-d995-4702-8bf7-40d4f69f94bc"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // UserAction
        m_UserAction = asset.FindActionMap("UserAction", throwIfNotFound: true);
        m_UserAction_LeftMouseClick = m_UserAction.FindAction("LeftMouseClick", throwIfNotFound: true);
        m_UserAction_MousePosition = m_UserAction.FindAction("MousePosition", throwIfNotFound: true);
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

    // UserAction
    private readonly InputActionMap m_UserAction;
    private IUserActionActions m_UserActionActionsCallbackInterface;
    private readonly InputAction m_UserAction_LeftMouseClick;
    private readonly InputAction m_UserAction_MousePosition;
    public struct UserActionActions
    {
        private @UserControls m_Wrapper;
        public UserActionActions(@UserControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftMouseClick => m_Wrapper.m_UserAction_LeftMouseClick;
        public InputAction @MousePosition => m_Wrapper.m_UserAction_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_UserAction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UserActionActions set) { return set.Get(); }
        public void SetCallbacks(IUserActionActions instance)
        {
            if (m_Wrapper.m_UserActionActionsCallbackInterface != null)
            {
                @LeftMouseClick.started -= m_Wrapper.m_UserActionActionsCallbackInterface.OnLeftMouseClick;
                @LeftMouseClick.performed -= m_Wrapper.m_UserActionActionsCallbackInterface.OnLeftMouseClick;
                @LeftMouseClick.canceled -= m_Wrapper.m_UserActionActionsCallbackInterface.OnLeftMouseClick;
                @MousePosition.started -= m_Wrapper.m_UserActionActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_UserActionActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_UserActionActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_UserActionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftMouseClick.started += instance.OnLeftMouseClick;
                @LeftMouseClick.performed += instance.OnLeftMouseClick;
                @LeftMouseClick.canceled += instance.OnLeftMouseClick;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public UserActionActions @UserAction => new UserActionActions(this);
    public interface IUserActionActions
    {
        void OnLeftMouseClick(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
}
