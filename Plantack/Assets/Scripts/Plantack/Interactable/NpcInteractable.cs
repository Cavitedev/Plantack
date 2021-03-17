using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Plantack.UI;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Localization;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Plantack.Interactable
{
    public class NpcInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] private MessageDisplay messageDisplay;
        public LocalizedString[] localizedMessages;
        private string[] _messages;


        public IInteractable.Interact GetInteractDelegate()
        {
            return Interact;
        }

        private void Interact()
        {
            StartCoroutine(InteractCoroutine());
        }

        private IEnumerator InteractCoroutine()
        {
            AsyncOperationHandle<string>[] asyncMessages =
                localizedMessages.Select(s => s.GetLocalizedString()).ToArray();
            _messages = new string[asyncMessages.Length];


            for (var i = 0; i < asyncMessages.Length; i++)
            {
                AsyncOperationHandle<string> asyncOperationHandle = asyncMessages[i];
                if (!asyncOperationHandle.IsDone)
                {
                    yield return asyncOperationHandle;
                }

                _messages[i] = asyncOperationHandle.Result;
            }

            messageDisplay.ShowMessages(_messages);
        }
    }
}