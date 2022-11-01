// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/GameInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputs"",
    ""maps"": [
        {
            ""name"": ""TV"",
            ""id"": ""0d59361b-63ea-4c12-96e7-422528f32baa"",
            ""actions"": [
                {
                    ""name"": ""NextCamera"",
                    ""type"": ""Button"",
                    ""id"": ""dede349b-a76f-42a3-b6e5-26debd143b6e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrevCamera"",
                    ""type"": ""Button"",
                    ""id"": ""2b278477-63b3-4e0a-a0a4-51fab664da4f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PowerOn"",
                    ""type"": ""Button"",
                    ""id"": ""1f63bd43-98b1-406a-9cf4-260388d54ded"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a87c9c82-d546-4297-a192-88016ff35108"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4af30288-08c5-4c5b-b4a7-b2f0172801d4"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrevCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""304210fc-126f-4bc3-8362-849f057acaea"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PowerOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player"",
            ""id"": ""e418e1cf-68ca-41b3-92dd-585d9ce1b7a2"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""839ed3a0-788d-40b0-8bb5-1c5db5b18fd0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interaction"",
                    ""type"": ""Button"",
                    ""id"": ""e949d5dc-f395-4402-a575-728879d27922"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""42101839-b5ee-4cc2-aa80-818174a303b3"",
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
                    ""id"": ""1545ba71-76d9-4289-8c35-4253061b2f3b"",
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
                    ""id"": ""3048cff7-7e44-40d0-a0a6-cb42e2f063cc"",
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
                    ""id"": ""03555808-8748-4557-90d2-14cd4f3ba402"",
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
                    ""id"": ""2802cda8-1012-48f3-9f3d-7ded1a87ab02"",
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
                    ""id"": ""d1009eaa-1f8f-41b8-b4e5-07aebbd3258e"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // TV
        m_TV = asset.FindActionMap("TV", throwIfNotFound: true);
        m_TV_NextCamera = m_TV.FindAction("NextCamera", throwIfNotFound: true);
        m_TV_PrevCamera = m_TV.FindAction("PrevCamera", throwIfNotFound: true);
        m_TV_PowerOn = m_TV.FindAction("PowerOn", throwIfNotFound: true);
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Interaction = m_Player.FindAction("Interaction", throwIfNotFound: true);
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

    // TV
    private readonly InputActionMap m_TV;
    private ITVActions m_TVActionsCallbackInterface;
    private readonly InputAction m_TV_NextCamera;
    private readonly InputAction m_TV_PrevCamera;
    private readonly InputAction m_TV_PowerOn;
    public struct TVActions
    {
        private @GameInputs m_Wrapper;
        public TVActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @NextCamera => m_Wrapper.m_TV_NextCamera;
        public InputAction @PrevCamera => m_Wrapper.m_TV_PrevCamera;
        public InputAction @PowerOn => m_Wrapper.m_TV_PowerOn;
        public InputActionMap Get() { return m_Wrapper.m_TV; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TVActions set) { return set.Get(); }
        public void SetCallbacks(ITVActions instance)
        {
            if (m_Wrapper.m_TVActionsCallbackInterface != null)
            {
                @NextCamera.started -= m_Wrapper.m_TVActionsCallbackInterface.OnNextCamera;
                @NextCamera.performed -= m_Wrapper.m_TVActionsCallbackInterface.OnNextCamera;
                @NextCamera.canceled -= m_Wrapper.m_TVActionsCallbackInterface.OnNextCamera;
                @PrevCamera.started -= m_Wrapper.m_TVActionsCallbackInterface.OnPrevCamera;
                @PrevCamera.performed -= m_Wrapper.m_TVActionsCallbackInterface.OnPrevCamera;
                @PrevCamera.canceled -= m_Wrapper.m_TVActionsCallbackInterface.OnPrevCamera;
                @PowerOn.started -= m_Wrapper.m_TVActionsCallbackInterface.OnPowerOn;
                @PowerOn.performed -= m_Wrapper.m_TVActionsCallbackInterface.OnPowerOn;
                @PowerOn.canceled -= m_Wrapper.m_TVActionsCallbackInterface.OnPowerOn;
            }
            m_Wrapper.m_TVActionsCallbackInterface = instance;
            if (instance != null)
            {
                @NextCamera.started += instance.OnNextCamera;
                @NextCamera.performed += instance.OnNextCamera;
                @NextCamera.canceled += instance.OnNextCamera;
                @PrevCamera.started += instance.OnPrevCamera;
                @PrevCamera.performed += instance.OnPrevCamera;
                @PrevCamera.canceled += instance.OnPrevCamera;
                @PowerOn.started += instance.OnPowerOn;
                @PowerOn.performed += instance.OnPowerOn;
                @PowerOn.canceled += instance.OnPowerOn;
            }
        }
    }
    public TVActions @TV => new TVActions(this);

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Interaction;
    public struct PlayerActions
    {
        private @GameInputs m_Wrapper;
        public PlayerActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Interaction => m_Wrapper.m_Player_Interaction;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Interaction.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteraction;
                @Interaction.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteraction;
                @Interaction.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteraction;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Interaction.started += instance.OnInteraction;
                @Interaction.performed += instance.OnInteraction;
                @Interaction.canceled += instance.OnInteraction;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface ITVActions
    {
        void OnNextCamera(InputAction.CallbackContext context);
        void OnPrevCamera(InputAction.CallbackContext context);
        void OnPowerOn(InputAction.CallbackContext context);
    }
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInteraction(InputAction.CallbackContext context);
    }
}
