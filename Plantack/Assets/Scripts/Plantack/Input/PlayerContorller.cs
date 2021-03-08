// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Plantack/Input/PlayerContorller.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Plantack.Input
{
    public class @PlayerController : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerController()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerContorller"",
    ""maps"": [
        {
            ""name"": ""InputMap"",
            ""id"": ""e9be3853-4742-4e83-8924-2296ca85c2ab"",
            ""actions"": [
                {
                    ""name"": ""Basic"",
                    ""type"": ""Value"",
                    ""id"": ""36a29f53-eb0c-4f47-a995-d128d88a74ed"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""4b391e19-1509-4bf1-85c1-f7924f9f9a74"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fall"",
                    ""type"": ""Button"",
                    ""id"": ""6e7c9038-b940-43f2-add4-5dcafa8de924"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""3797141f-f1e9-4dc1-a880-14ae858b5409"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""412a7589-7da6-4f69-a2b7-8616cea2de0d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Climb"",
                    ""type"": ""Value"",
                    ""id"": ""fd107103-3eca-4cf0-a4f5-9d64144d5b91"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Enter"",
                    ""type"": ""Button"",
                    ""id"": ""e15b5464-1512-4e51-94e8-531315be2275"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""AD"",
                    ""id"": ""3c1a62f5-5e1b-48da-b0c2-da2f52706690"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Basic"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d8645fb8-56f0-49df-9725-6076efcf5ab3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Basic"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""3c9e824c-ab08-4e13-b350-0aeb691a8611"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Basic"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""c0abac32-acef-4e7b-95ef-6aba06a2d028"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Basic"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""2086aa6f-fd81-4268-b44f-fc14219cc80e"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Basic"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""eeda8ce2-6505-46f2-8969-ee2c65ee0c72"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Basic"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""921a0095-f2c2-4f09-9287-ed470b83e891"",
                    ""path"": ""<AndroidGamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Basic"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31de11b5-adc6-4142-9964-277072d0ee1c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab280a97-040e-4cc9-84d7-cefc9c6c351e"",
                    ""path"": ""<AndroidGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5da60dd8-3e37-430a-81e3-6deeaad9f28b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Fall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5b861f0-bc80-4b34-9750-d3e070075cd2"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Fall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8fe2508f-e946-40d7-a4f0-4a77faf6f7e2"",
                    ""path"": ""<AndroidGamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Fall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48c936d1-53b8-45dd-b804-548502af6ded"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2a380a2-3921-4f5b-b114-315e6aaf23c2"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""74ec818e-a050-4320-89cb-0431e4658f2d"",
                    ""path"": ""<AndroidGamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WS"",
                    ""id"": ""046c5d39-7017-402a-9c4e-959fa90ca80b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Climb"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""bc33619d-904e-4870-8767-2c32c2554c90"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Climb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""3de4d5a1-ce82-460b-9343-f71853dd3fd1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Climb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""bd3b817c-a782-48fb-af04-2d51a332571f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Climb"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""8326ef67-3823-4f0d-b7d9-62c32a3efd06"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Climb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""1d631daf-9140-4506-bf53-2d44f49c625f"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Climb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b9bba6dc-ad47-4ca1-b0a8-ea16f76ed7dd"",
                    ""path"": ""<AndroidGamepad>/leftStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Climb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3487c78c-181d-44bb-b8e6-b856ca6baf7f"",
                    ""path"": ""<AndroidGamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59259656-3966-4a62-a661-2a306881aaf9"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1f4d4c4-3b47-4b24-990d-ff23b35d51e8"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": []
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": []
        }
    ]
}");
            // InputMap
            m_InputMap = asset.FindActionMap("InputMap", throwIfNotFound: true);
            m_InputMap_Basic = m_InputMap.FindAction("Basic", throwIfNotFound: true);
            m_InputMap_Jump = m_InputMap.FindAction("Jump", throwIfNotFound: true);
            m_InputMap_Fall = m_InputMap.FindAction("Fall", throwIfNotFound: true);
            m_InputMap_Dash = m_InputMap.FindAction("Dash", throwIfNotFound: true);
            m_InputMap_Run = m_InputMap.FindAction("Run", throwIfNotFound: true);
            m_InputMap_Climb = m_InputMap.FindAction("Climb", throwIfNotFound: true);
            m_InputMap_Enter = m_InputMap.FindAction("Enter", throwIfNotFound: true);
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

        // InputMap
        private readonly InputActionMap m_InputMap;
        private IInputMapActions m_InputMapActionsCallbackInterface;
        private readonly InputAction m_InputMap_Basic;
        private readonly InputAction m_InputMap_Jump;
        private readonly InputAction m_InputMap_Fall;
        private readonly InputAction m_InputMap_Dash;
        private readonly InputAction m_InputMap_Run;
        private readonly InputAction m_InputMap_Climb;
        private readonly InputAction m_InputMap_Enter;
        public struct InputMapActions
        {
            private @PlayerController m_Wrapper;
            public InputMapActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
            public InputAction @Basic => m_Wrapper.m_InputMap_Basic;
            public InputAction @Jump => m_Wrapper.m_InputMap_Jump;
            public InputAction @Fall => m_Wrapper.m_InputMap_Fall;
            public InputAction @Dash => m_Wrapper.m_InputMap_Dash;
            public InputAction @Run => m_Wrapper.m_InputMap_Run;
            public InputAction @Climb => m_Wrapper.m_InputMap_Climb;
            public InputAction @Enter => m_Wrapper.m_InputMap_Enter;
            public InputActionMap Get() { return m_Wrapper.m_InputMap; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(InputMapActions set) { return set.Get(); }
            public void SetCallbacks(IInputMapActions instance)
            {
                if (m_Wrapper.m_InputMapActionsCallbackInterface != null)
                {
                    @Basic.started -= m_Wrapper.m_InputMapActionsCallbackInterface.OnBasic;
                    @Basic.performed -= m_Wrapper.m_InputMapActionsCallbackInterface.OnBasic;
                    @Basic.canceled -= m_Wrapper.m_InputMapActionsCallbackInterface.OnBasic;
                    @Jump.started -= m_Wrapper.m_InputMapActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_InputMapActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_InputMapActionsCallbackInterface.OnJump;
                    @Fall.started -= m_Wrapper.m_InputMapActionsCallbackInterface.OnFall;
                    @Fall.performed -= m_Wrapper.m_InputMapActionsCallbackInterface.OnFall;
                    @Fall.canceled -= m_Wrapper.m_InputMapActionsCallbackInterface.OnFall;
                    @Dash.started -= m_Wrapper.m_InputMapActionsCallbackInterface.OnDash;
                    @Dash.performed -= m_Wrapper.m_InputMapActionsCallbackInterface.OnDash;
                    @Dash.canceled -= m_Wrapper.m_InputMapActionsCallbackInterface.OnDash;
                    @Run.started -= m_Wrapper.m_InputMapActionsCallbackInterface.OnRun;
                    @Run.performed -= m_Wrapper.m_InputMapActionsCallbackInterface.OnRun;
                    @Run.canceled -= m_Wrapper.m_InputMapActionsCallbackInterface.OnRun;
                    @Climb.started -= m_Wrapper.m_InputMapActionsCallbackInterface.OnClimb;
                    @Climb.performed -= m_Wrapper.m_InputMapActionsCallbackInterface.OnClimb;
                    @Climb.canceled -= m_Wrapper.m_InputMapActionsCallbackInterface.OnClimb;
                    @Enter.started -= m_Wrapper.m_InputMapActionsCallbackInterface.OnEnter;
                    @Enter.performed -= m_Wrapper.m_InputMapActionsCallbackInterface.OnEnter;
                    @Enter.canceled -= m_Wrapper.m_InputMapActionsCallbackInterface.OnEnter;
                }
                m_Wrapper.m_InputMapActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Basic.started += instance.OnBasic;
                    @Basic.performed += instance.OnBasic;
                    @Basic.canceled += instance.OnBasic;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Fall.started += instance.OnFall;
                    @Fall.performed += instance.OnFall;
                    @Fall.canceled += instance.OnFall;
                    @Dash.started += instance.OnDash;
                    @Dash.performed += instance.OnDash;
                    @Dash.canceled += instance.OnDash;
                    @Run.started += instance.OnRun;
                    @Run.performed += instance.OnRun;
                    @Run.canceled += instance.OnRun;
                    @Climb.started += instance.OnClimb;
                    @Climb.performed += instance.OnClimb;
                    @Climb.canceled += instance.OnClimb;
                    @Enter.started += instance.OnEnter;
                    @Enter.performed += instance.OnEnter;
                    @Enter.canceled += instance.OnEnter;
                }
            }
        }
        public InputMapActions @InputMap => new InputMapActions(this);
        private int m_GamepadSchemeIndex = -1;
        public InputControlScheme GamepadScheme
        {
            get
            {
                if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
                return asset.controlSchemes[m_GamepadSchemeIndex];
            }
        }
        private int m_KeyboardSchemeIndex = -1;
        public InputControlScheme KeyboardScheme
        {
            get
            {
                if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
                return asset.controlSchemes[m_KeyboardSchemeIndex];
            }
        }
        public interface IInputMapActions
        {
            void OnBasic(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnFall(InputAction.CallbackContext context);
            void OnDash(InputAction.CallbackContext context);
            void OnRun(InputAction.CallbackContext context);
            void OnClimb(InputAction.CallbackContext context);
            void OnEnter(InputAction.CallbackContext context);
        }
    }
}
