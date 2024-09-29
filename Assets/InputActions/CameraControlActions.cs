//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/InputActions/CameraControlActions.inputactions
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

public partial class @CameraControlActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CameraControlActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CameraControlActions"",
    ""maps"": [
        {
            ""name"": ""Input Device"",
            ""id"": ""ea3bb453-ebf1-4c65-b1f1-720fd0d90c26"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""e5805398-15a7-41c9-9a23-124f6996ca69"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""acb1b569-c0b5-4719-8f89-99b7acffc2c3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Value"",
                    ""id"": ""bdd4d118-4aae-4622-b4e1-d712d5b9033c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Drag"",
                    ""type"": ""Button"",
                    ""id"": ""d4cd4b8e-1335-4e9c-90da-4162bf124b7e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""0a93c6a6-ddf9-4b95-8d56-7fe9b4dee133"",
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
                    ""id"": ""6415d8a2-3317-408d-8ee4-2b0084d72052"",
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
                    ""id"": ""435e2ed4-cbbf-485b-bc70-6092e16e630a"",
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
                    ""id"": ""0fed3d54-5970-4c09-8362-9c5c8d4f8c62"",
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
                    ""id"": ""c043ba20-ebb2-4a9f-b5a5-dd38fec37a20"",
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
                    ""id"": ""6730d643-62c6-45ad-a911-3a138d14e8e3"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e96d018-ce57-4043-baf8-8996e78b9b18"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""MouseRightButton"",
                    ""id"": ""9c7add53-7bef-4751-bf77-62eb3aded4b1"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""00da6650-df86-4ea7-8d63-74b004b6fc8a"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""d9099c30-8f9e-429d-811f-11f8caad4f49"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""884a8605-dc5d-4742-8c1b-389814ab288e"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""MouseMiddleButton"",
                    ""id"": ""5a427c4e-c4a4-493d-80c8-e0e535cb6432"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drag"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""11809dd6-d08f-4ee8-b73a-a91343356233"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""fd8432a1-bf75-4ec5-a4f0-9bb33a7d1909"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Touch Screen"",
            ""id"": ""131c4724-8d99-4efa-9772-3db20e8fdab2"",
            ""actions"": [
                {
                    ""name"": ""PrimaryFingerPosition"",
                    ""type"": ""Value"",
                    ""id"": ""60b90268-ad7e-4d2a-994a-d1f28194a1b4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SecondaryFingerPosition"",
                    ""type"": ""Value"",
                    ""id"": ""eef19dea-c540-4245-9509-36e5abc2cdbf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SecondaryTouchContact"",
                    ""type"": ""Button"",
                    ""id"": ""efe51f89-0f22-4993-b3e2-99ee41bab430"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""88bb3308-378a-43e1-a751-313bc967670b"",
                    ""path"": ""<Touchscreen>/touch0/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryFingerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db28f5b5-de1e-49cb-8709-2dd45158627d"",
                    ""path"": ""<Touchscreen>/touch1/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryFingerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36999c32-704c-4b66-9fdf-f9b5236759ab"",
                    ""path"": ""<Touchscreen>/touch1/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryTouchContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Input Device
        m_InputDevice = asset.FindActionMap("Input Device", throwIfNotFound: true);
        m_InputDevice_Movement = m_InputDevice.FindAction("Movement", throwIfNotFound: true);
        m_InputDevice_Rotate = m_InputDevice.FindAction("Rotate", throwIfNotFound: true);
        m_InputDevice_Zoom = m_InputDevice.FindAction("Zoom", throwIfNotFound: true);
        m_InputDevice_Drag = m_InputDevice.FindAction("Drag", throwIfNotFound: true);
        // Touch Screen
        m_TouchScreen = asset.FindActionMap("Touch Screen", throwIfNotFound: true);
        m_TouchScreen_PrimaryFingerPosition = m_TouchScreen.FindAction("PrimaryFingerPosition", throwIfNotFound: true);
        m_TouchScreen_SecondaryFingerPosition = m_TouchScreen.FindAction("SecondaryFingerPosition", throwIfNotFound: true);
        m_TouchScreen_SecondaryTouchContact = m_TouchScreen.FindAction("SecondaryTouchContact", throwIfNotFound: true);
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

    // Input Device
    private readonly InputActionMap m_InputDevice;
    private List<IInputDeviceActions> m_InputDeviceActionsCallbackInterfaces = new List<IInputDeviceActions>();
    private readonly InputAction m_InputDevice_Movement;
    private readonly InputAction m_InputDevice_Rotate;
    private readonly InputAction m_InputDevice_Zoom;
    private readonly InputAction m_InputDevice_Drag;
    public struct InputDeviceActions
    {
        private @CameraControlActions m_Wrapper;
        public InputDeviceActions(@CameraControlActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_InputDevice_Movement;
        public InputAction @Rotate => m_Wrapper.m_InputDevice_Rotate;
        public InputAction @Zoom => m_Wrapper.m_InputDevice_Zoom;
        public InputAction @Drag => m_Wrapper.m_InputDevice_Drag;
        public InputActionMap Get() { return m_Wrapper.m_InputDevice; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputDeviceActions set) { return set.Get(); }
        public void AddCallbacks(IInputDeviceActions instance)
        {
            if (instance == null || m_Wrapper.m_InputDeviceActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InputDeviceActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Rotate.started += instance.OnRotate;
            @Rotate.performed += instance.OnRotate;
            @Rotate.canceled += instance.OnRotate;
            @Zoom.started += instance.OnZoom;
            @Zoom.performed += instance.OnZoom;
            @Zoom.canceled += instance.OnZoom;
            @Drag.started += instance.OnDrag;
            @Drag.performed += instance.OnDrag;
            @Drag.canceled += instance.OnDrag;
        }

        private void UnregisterCallbacks(IInputDeviceActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Rotate.started -= instance.OnRotate;
            @Rotate.performed -= instance.OnRotate;
            @Rotate.canceled -= instance.OnRotate;
            @Zoom.started -= instance.OnZoom;
            @Zoom.performed -= instance.OnZoom;
            @Zoom.canceled -= instance.OnZoom;
            @Drag.started -= instance.OnDrag;
            @Drag.performed -= instance.OnDrag;
            @Drag.canceled -= instance.OnDrag;
        }

        public void RemoveCallbacks(IInputDeviceActions instance)
        {
            if (m_Wrapper.m_InputDeviceActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInputDeviceActions instance)
        {
            foreach (var item in m_Wrapper.m_InputDeviceActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InputDeviceActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InputDeviceActions @InputDevice => new InputDeviceActions(this);

    // Touch Screen
    private readonly InputActionMap m_TouchScreen;
    private List<ITouchScreenActions> m_TouchScreenActionsCallbackInterfaces = new List<ITouchScreenActions>();
    private readonly InputAction m_TouchScreen_PrimaryFingerPosition;
    private readonly InputAction m_TouchScreen_SecondaryFingerPosition;
    private readonly InputAction m_TouchScreen_SecondaryTouchContact;
    public struct TouchScreenActions
    {
        private @CameraControlActions m_Wrapper;
        public TouchScreenActions(@CameraControlActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryFingerPosition => m_Wrapper.m_TouchScreen_PrimaryFingerPosition;
        public InputAction @SecondaryFingerPosition => m_Wrapper.m_TouchScreen_SecondaryFingerPosition;
        public InputAction @SecondaryTouchContact => m_Wrapper.m_TouchScreen_SecondaryTouchContact;
        public InputActionMap Get() { return m_Wrapper.m_TouchScreen; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchScreenActions set) { return set.Get(); }
        public void AddCallbacks(ITouchScreenActions instance)
        {
            if (instance == null || m_Wrapper.m_TouchScreenActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_TouchScreenActionsCallbackInterfaces.Add(instance);
            @PrimaryFingerPosition.started += instance.OnPrimaryFingerPosition;
            @PrimaryFingerPosition.performed += instance.OnPrimaryFingerPosition;
            @PrimaryFingerPosition.canceled += instance.OnPrimaryFingerPosition;
            @SecondaryFingerPosition.started += instance.OnSecondaryFingerPosition;
            @SecondaryFingerPosition.performed += instance.OnSecondaryFingerPosition;
            @SecondaryFingerPosition.canceled += instance.OnSecondaryFingerPosition;
            @SecondaryTouchContact.started += instance.OnSecondaryTouchContact;
            @SecondaryTouchContact.performed += instance.OnSecondaryTouchContact;
            @SecondaryTouchContact.canceled += instance.OnSecondaryTouchContact;
        }

        private void UnregisterCallbacks(ITouchScreenActions instance)
        {
            @PrimaryFingerPosition.started -= instance.OnPrimaryFingerPosition;
            @PrimaryFingerPosition.performed -= instance.OnPrimaryFingerPosition;
            @PrimaryFingerPosition.canceled -= instance.OnPrimaryFingerPosition;
            @SecondaryFingerPosition.started -= instance.OnSecondaryFingerPosition;
            @SecondaryFingerPosition.performed -= instance.OnSecondaryFingerPosition;
            @SecondaryFingerPosition.canceled -= instance.OnSecondaryFingerPosition;
            @SecondaryTouchContact.started -= instance.OnSecondaryTouchContact;
            @SecondaryTouchContact.performed -= instance.OnSecondaryTouchContact;
            @SecondaryTouchContact.canceled -= instance.OnSecondaryTouchContact;
        }

        public void RemoveCallbacks(ITouchScreenActions instance)
        {
            if (m_Wrapper.m_TouchScreenActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ITouchScreenActions instance)
        {
            foreach (var item in m_Wrapper.m_TouchScreenActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_TouchScreenActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public TouchScreenActions @TouchScreen => new TouchScreenActions(this);
    public interface IInputDeviceActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
        void OnDrag(InputAction.CallbackContext context);
    }
    public interface ITouchScreenActions
    {
        void OnPrimaryFingerPosition(InputAction.CallbackContext context);
        void OnSecondaryFingerPosition(InputAction.CallbackContext context);
        void OnSecondaryTouchContact(InputAction.CallbackContext context);
    }
}
