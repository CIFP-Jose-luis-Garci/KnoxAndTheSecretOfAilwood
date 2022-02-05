// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InpuCr.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InpuCr : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InpuCr()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InpuCr"",
    ""maps"": [
        {
            ""name"": ""Knox"",
            ""id"": ""0b36bb0f-af4a-490e-a048-944e4b20ec73"",
            ""actions"": [
                {
                    ""name"": ""Andar"",
                    ""type"": ""Value"",
                    ""id"": ""163d0a64-9ad0-4453-8079-c930315ed37f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Correr"",
                    ""type"": ""Button"",
                    ""id"": ""3433d957-4a2c-435e-87c1-6898b8f4e67e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Atacar"",
                    ""type"": ""Button"",
                    ""id"": ""c700fdad-20aa-4234-98d0-c36d083036fd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""310e560c-eb3c-4105-9fc1-7be3be739413"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Andar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b8fcbab-de05-4426-b61d-ba84b7cee317"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Correr"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76243891-b27a-48f8-8d7b-884f827e23aa"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Atacar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Knox
        m_Knox = asset.FindActionMap("Knox", throwIfNotFound: true);
        m_Knox_Andar = m_Knox.FindAction("Andar", throwIfNotFound: true);
        m_Knox_Correr = m_Knox.FindAction("Correr", throwIfNotFound: true);
        m_Knox_Atacar = m_Knox.FindAction("Atacar", throwIfNotFound: true);
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

    // Knox
    private readonly InputActionMap m_Knox;
    private IKnoxActions m_KnoxActionsCallbackInterface;
    private readonly InputAction m_Knox_Andar;
    private readonly InputAction m_Knox_Correr;
    private readonly InputAction m_Knox_Atacar;
    public struct KnoxActions
    {
        private @InpuCr m_Wrapper;
        public KnoxActions(@InpuCr wrapper) { m_Wrapper = wrapper; }
        public InputAction @Andar => m_Wrapper.m_Knox_Andar;
        public InputAction @Correr => m_Wrapper.m_Knox_Correr;
        public InputAction @Atacar => m_Wrapper.m_Knox_Atacar;
        public InputActionMap Get() { return m_Wrapper.m_Knox; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KnoxActions set) { return set.Get(); }
        public void SetCallbacks(IKnoxActions instance)
        {
            if (m_Wrapper.m_KnoxActionsCallbackInterface != null)
            {
                @Andar.started -= m_Wrapper.m_KnoxActionsCallbackInterface.OnAndar;
                @Andar.performed -= m_Wrapper.m_KnoxActionsCallbackInterface.OnAndar;
                @Andar.canceled -= m_Wrapper.m_KnoxActionsCallbackInterface.OnAndar;
                @Correr.started -= m_Wrapper.m_KnoxActionsCallbackInterface.OnCorrer;
                @Correr.performed -= m_Wrapper.m_KnoxActionsCallbackInterface.OnCorrer;
                @Correr.canceled -= m_Wrapper.m_KnoxActionsCallbackInterface.OnCorrer;
                @Atacar.started -= m_Wrapper.m_KnoxActionsCallbackInterface.OnAtacar;
                @Atacar.performed -= m_Wrapper.m_KnoxActionsCallbackInterface.OnAtacar;
                @Atacar.canceled -= m_Wrapper.m_KnoxActionsCallbackInterface.OnAtacar;
            }
            m_Wrapper.m_KnoxActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Andar.started += instance.OnAndar;
                @Andar.performed += instance.OnAndar;
                @Andar.canceled += instance.OnAndar;
                @Correr.started += instance.OnCorrer;
                @Correr.performed += instance.OnCorrer;
                @Correr.canceled += instance.OnCorrer;
                @Atacar.started += instance.OnAtacar;
                @Atacar.performed += instance.OnAtacar;
                @Atacar.canceled += instance.OnAtacar;
            }
        }
    }
    public KnoxActions @Knox => new KnoxActions(this);
    public interface IKnoxActions
    {
        void OnAndar(InputAction.CallbackContext context);
        void OnCorrer(InputAction.CallbackContext context);
        void OnAtacar(InputAction.CallbackContext context);
    }
}
