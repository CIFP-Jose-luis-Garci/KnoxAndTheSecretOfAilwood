// GENERATED AUTOMATICALLY FROM 'Assets/InputSettings/Controles.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controles : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controles()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controles"",
    ""maps"": [
        {
            ""name"": ""Moverse"",
            ""id"": ""b5af89f0-fe04-4b2f-b68d-54088e47aac5"",
            ""actions"": [
                {
                    ""name"": ""Mover"",
                    ""type"": ""Value"",
                    ""id"": ""f564c045-feec-47da-8f52-b9cde55bd447"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""958ef942-9948-4e09-a57c-8c7c118513c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rodar"",
                    ""type"": ""Button"",
                    ""id"": ""7c15cda6-488b-46d8-b640-c238cfc396ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Saltar"",
                    ""type"": ""Button"",
                    ""id"": ""4d9bb091-9b5f-4aa1-827c-9932b09430da"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dcc946a5-af61-4809-9740-52e87a79423e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1d8c93b-4feb-4494-b758-49d473c54bc0"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47f4efa9-bc72-4314-b46e-aea293c69f06"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rodar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""99322505-d645-43f0-bbb3-5e9c4038a393"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Saltar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Moverse
        m_Moverse = asset.FindActionMap("Moverse", throwIfNotFound: true);
        m_Moverse_Mover = m_Moverse.FindAction("Mover", throwIfNotFound: true);
        m_Moverse_Run = m_Moverse.FindAction("Run", throwIfNotFound: true);
        m_Moverse_Rodar = m_Moverse.FindAction("Rodar", throwIfNotFound: true);
        m_Moverse_Saltar = m_Moverse.FindAction("Saltar", throwIfNotFound: true);
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

    // Moverse
    private readonly InputActionMap m_Moverse;
    private IMoverseActions m_MoverseActionsCallbackInterface;
    private readonly InputAction m_Moverse_Mover;
    private readonly InputAction m_Moverse_Run;
    private readonly InputAction m_Moverse_Rodar;
    private readonly InputAction m_Moverse_Saltar;
    public struct MoverseActions
    {
        private @Controles m_Wrapper;
        public MoverseActions(@Controles wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mover => m_Wrapper.m_Moverse_Mover;
        public InputAction @Run => m_Wrapper.m_Moverse_Run;
        public InputAction @Rodar => m_Wrapper.m_Moverse_Rodar;
        public InputAction @Saltar => m_Wrapper.m_Moverse_Saltar;
        public InputActionMap Get() { return m_Wrapper.m_Moverse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MoverseActions set) { return set.Get(); }
        public void SetCallbacks(IMoverseActions instance)
        {
            if (m_Wrapper.m_MoverseActionsCallbackInterface != null)
            {
                @Mover.started -= m_Wrapper.m_MoverseActionsCallbackInterface.OnMover;
                @Mover.performed -= m_Wrapper.m_MoverseActionsCallbackInterface.OnMover;
                @Mover.canceled -= m_Wrapper.m_MoverseActionsCallbackInterface.OnMover;
                @Run.started -= m_Wrapper.m_MoverseActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_MoverseActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_MoverseActionsCallbackInterface.OnRun;
                @Rodar.started -= m_Wrapper.m_MoverseActionsCallbackInterface.OnRodar;
                @Rodar.performed -= m_Wrapper.m_MoverseActionsCallbackInterface.OnRodar;
                @Rodar.canceled -= m_Wrapper.m_MoverseActionsCallbackInterface.OnRodar;
                @Saltar.started -= m_Wrapper.m_MoverseActionsCallbackInterface.OnSaltar;
                @Saltar.performed -= m_Wrapper.m_MoverseActionsCallbackInterface.OnSaltar;
                @Saltar.canceled -= m_Wrapper.m_MoverseActionsCallbackInterface.OnSaltar;
            }
            m_Wrapper.m_MoverseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Mover.started += instance.OnMover;
                @Mover.performed += instance.OnMover;
                @Mover.canceled += instance.OnMover;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Rodar.started += instance.OnRodar;
                @Rodar.performed += instance.OnRodar;
                @Rodar.canceled += instance.OnRodar;
                @Saltar.started += instance.OnSaltar;
                @Saltar.performed += instance.OnSaltar;
                @Saltar.canceled += instance.OnSaltar;
            }
        }
    }
    public MoverseActions @Moverse => new MoverseActions(this);
    public interface IMoverseActions
    {
        void OnMover(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnRodar(InputAction.CallbackContext context);
        void OnSaltar(InputAction.CallbackContext context);
    }
}
