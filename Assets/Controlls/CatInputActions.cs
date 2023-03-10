//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Controlls/CatInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @CatInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CatInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CatInputActions"",
    ""maps"": [
        {
            ""name"": ""TopDown"",
            ""id"": ""6818c51a-df3d-492e-ae5e-127292af1b91"",
            ""actions"": [
                {
                    ""name"": ""UseWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""174a122e-536e-4593-9070-4246175be907"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwitchWeapons"",
                    ""type"": ""Button"",
                    ""id"": ""53e3041a-1aa2-4d01-a708-18ad43b2a9e3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""c7007744-d3de-40eb-a706-9e6992c06fab"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""1bb04488-d570-4c4e-aace-2231f0e585e3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ReloadWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""62081b26-5145-4c27-b39e-4e928affb890"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""8ce25331-4f79-46a2-9e7a-2c0255c69eea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""409b2d82-18fe-45ac-9159-e71285231739"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b04013ce-4816-4795-8a66-ff60c0f19e78"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""162af4e5-5d69-4ac4-a663-8886384c34e7"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1cd562e2-d65a-43f6-a833-82a2dd165cd6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""000d3b10-d74a-4348-b812-6b8ed30e6f76"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""11613f67-27b2-443b-98f4-299e8088c328"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a3cf8ffd-72c2-4538-ac68-de289f8bdc3a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c989aa77-cf6b-4294-95a1-497acd4a0ee4"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f99ce79a-00aa-40cf-8508-1ca4a2428b20"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReloadWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd788975-c7b4-42c1-a716-ef1ae8a1291f"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // TopDown
        m_TopDown = asset.FindActionMap("TopDown", throwIfNotFound: true);
        m_TopDown_UseWeapon = m_TopDown.FindAction("UseWeapon", throwIfNotFound: true);
        m_TopDown_SwitchWeapons = m_TopDown.FindAction("SwitchWeapons", throwIfNotFound: true);
        m_TopDown_Movement = m_TopDown.FindAction("Movement", throwIfNotFound: true);
        m_TopDown_Dash = m_TopDown.FindAction("Dash", throwIfNotFound: true);
        m_TopDown_ReloadWeapon = m_TopDown.FindAction("ReloadWeapon", throwIfNotFound: true);
        m_TopDown_Pause = m_TopDown.FindAction("Pause", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // TopDown
    private readonly InputActionMap m_TopDown;
    private ITopDownActions m_TopDownActionsCallbackInterface;
    private readonly InputAction m_TopDown_UseWeapon;
    private readonly InputAction m_TopDown_SwitchWeapons;
    private readonly InputAction m_TopDown_Movement;
    private readonly InputAction m_TopDown_Dash;
    private readonly InputAction m_TopDown_ReloadWeapon;
    private readonly InputAction m_TopDown_Pause;
    public struct TopDownActions
    {
        private @CatInputActions m_Wrapper;
        public TopDownActions(@CatInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @UseWeapon => m_Wrapper.m_TopDown_UseWeapon;
        public InputAction @SwitchWeapons => m_Wrapper.m_TopDown_SwitchWeapons;
        public InputAction @Movement => m_Wrapper.m_TopDown_Movement;
        public InputAction @Dash => m_Wrapper.m_TopDown_Dash;
        public InputAction @ReloadWeapon => m_Wrapper.m_TopDown_ReloadWeapon;
        public InputAction @Pause => m_Wrapper.m_TopDown_Pause;
        public InputActionMap Get() { return m_Wrapper.m_TopDown; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TopDownActions set) { return set.Get(); }
        public void SetCallbacks(ITopDownActions instance)
        {
            if (m_Wrapper.m_TopDownActionsCallbackInterface != null)
            {
                @UseWeapon.started -= m_Wrapper.m_TopDownActionsCallbackInterface.OnUseWeapon;
                @UseWeapon.performed -= m_Wrapper.m_TopDownActionsCallbackInterface.OnUseWeapon;
                @UseWeapon.canceled -= m_Wrapper.m_TopDownActionsCallbackInterface.OnUseWeapon;
                @SwitchWeapons.started -= m_Wrapper.m_TopDownActionsCallbackInterface.OnSwitchWeapons;
                @SwitchWeapons.performed -= m_Wrapper.m_TopDownActionsCallbackInterface.OnSwitchWeapons;
                @SwitchWeapons.canceled -= m_Wrapper.m_TopDownActionsCallbackInterface.OnSwitchWeapons;
                @Movement.started -= m_Wrapper.m_TopDownActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_TopDownActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_TopDownActionsCallbackInterface.OnMovement;
                @Dash.started -= m_Wrapper.m_TopDownActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_TopDownActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_TopDownActionsCallbackInterface.OnDash;
                @ReloadWeapon.started -= m_Wrapper.m_TopDownActionsCallbackInterface.OnReloadWeapon;
                @ReloadWeapon.performed -= m_Wrapper.m_TopDownActionsCallbackInterface.OnReloadWeapon;
                @ReloadWeapon.canceled -= m_Wrapper.m_TopDownActionsCallbackInterface.OnReloadWeapon;
                @Pause.started -= m_Wrapper.m_TopDownActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_TopDownActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_TopDownActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_TopDownActionsCallbackInterface = instance;
            if (instance != null)
            {
                @UseWeapon.started += instance.OnUseWeapon;
                @UseWeapon.performed += instance.OnUseWeapon;
                @UseWeapon.canceled += instance.OnUseWeapon;
                @SwitchWeapons.started += instance.OnSwitchWeapons;
                @SwitchWeapons.performed += instance.OnSwitchWeapons;
                @SwitchWeapons.canceled += instance.OnSwitchWeapons;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @ReloadWeapon.started += instance.OnReloadWeapon;
                @ReloadWeapon.performed += instance.OnReloadWeapon;
                @ReloadWeapon.canceled += instance.OnReloadWeapon;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public TopDownActions @TopDown => new TopDownActions(this);
    public interface ITopDownActions
    {
        void OnUseWeapon(InputAction.CallbackContext context);
        void OnSwitchWeapons(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnReloadWeapon(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
