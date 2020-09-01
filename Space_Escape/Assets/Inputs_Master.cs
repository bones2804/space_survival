// GENERATED AUTOMATICALLY FROM 'Assets/Inputs_Master.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Inputs_Master : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs_Master()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs_Master"",
    ""maps"": [
        {
            ""name"": ""Crew"",
            ""id"": ""3b4876a4-3ebb-4cd3-b2e8-cb600b92e06f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""222a4d33-b945-4f38-860d-14b09bd03f31"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""2c6d01c7-222a-474e-bba7-daee61cc1704"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""53afcce6-10f9-4d52-ac4d-2bcd18e7b9ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""5b3287a9-6b31-45d6-b79b-ba3d5d566a3f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2af1adce-5023-4e7e-b3bd-db562c42fbf0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2032d414-ab11-4779-bd90-d8fe8ae5f67a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""865a9eb8-4dac-4116-a723-f18ce4b5bda0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7510d796-2d72-4027-bbac-e18159ec144a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""8810aa59-52c7-4fc5-a3de-b12e2f1a5a36"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""da4bb319-f2e8-4d7b-a15b-15b8e522cda2"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9938ab94-1fd0-40b7-a3bb-30db6e104b25"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a7f76d34-92c7-49a7-a277-c7c294bef75a"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""aa154aa9-3d63-46e8-971e-d6ff7a58a4ee"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""508e66ee-1256-4557-866a-2f01af918d98"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07ebea9c-75f6-480a-90ff-4ab0215f8fde"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Crew
        m_Crew = asset.FindActionMap("Crew", throwIfNotFound: true);
        m_Crew_Move = m_Crew.FindAction("Move", throwIfNotFound: true);
        m_Crew_Run = m_Crew.FindAction("Run", throwIfNotFound: true);
        m_Crew_Dash = m_Crew.FindAction("Dash", throwIfNotFound: true);
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

    // Crew
    private readonly InputActionMap m_Crew;
    private ICrewActions m_CrewActionsCallbackInterface;
    private readonly InputAction m_Crew_Move;
    private readonly InputAction m_Crew_Run;
    private readonly InputAction m_Crew_Dash;
    public struct CrewActions
    {
        private @Inputs_Master m_Wrapper;
        public CrewActions(@Inputs_Master wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Crew_Move;
        public InputAction @Run => m_Wrapper.m_Crew_Run;
        public InputAction @Dash => m_Wrapper.m_Crew_Dash;
        public InputActionMap Get() { return m_Wrapper.m_Crew; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CrewActions set) { return set.Get(); }
        public void SetCallbacks(ICrewActions instance)
        {
            if (m_Wrapper.m_CrewActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_CrewActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CrewActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CrewActionsCallbackInterface.OnMove;
                @Run.started -= m_Wrapper.m_CrewActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_CrewActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_CrewActionsCallbackInterface.OnRun;
                @Dash.started -= m_Wrapper.m_CrewActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_CrewActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_CrewActionsCallbackInterface.OnDash;
            }
            m_Wrapper.m_CrewActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
            }
        }
    }
    public CrewActions @Crew => new CrewActions(this);
    public interface ICrewActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
}
