using System;
using System.Collections;
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

        public void Exit()
        {
            messageDisplay.Hide();
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

            ResourceManager resourceManager = Addressables.ResourceManager;
            for (var i = 0; i < asyncMessages.Length; i++)
            {
                AsyncOperationHandle<string> asyncOperationHandle = asyncMessages[i];
                resourceManager.Acquire(asyncOperationHandle);
                if (!asyncOperationHandle.IsDone)
                {
                    yield return asyncOperationHandle;
                }
                _messages[i] = asyncOperationHandle.Result;
                resourceManager.Release(asyncOperationHandle);
              
            }
            resourceManager.Dispose();
            messageDisplay.ShowMessages(_messages);
        }

        private void OnDestroy()
        {
            Addressables.ResourceManager.Dispose();
        }
    }
}