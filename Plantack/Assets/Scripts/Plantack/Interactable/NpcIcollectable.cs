using Plantack.UI;
using UnityEngine;

namespace Plantack.Interactable
{
    public class NpcIcollectable : MonoBehaviour, IInteractable
    {
        
        [SerializeField] private MessageDisplay messageDisplay;
        [SerializeField,TextArea] private string[] messages;
        
        
        
        public IInteractable.Interact GetInteractDelegate()
        {
            return Interact;
        }

        private void Interact()
        {
            messageDisplay.ShowMessages(messages);
        }
    }
}