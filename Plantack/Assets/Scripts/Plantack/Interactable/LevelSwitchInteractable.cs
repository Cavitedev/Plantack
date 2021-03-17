using UnityEngine;
using UnityEngine.SceneManagement;

namespace Plantack.Interactable
{
    public class LevelSwitchInteractable : MonoBehaviour, IInteractable
    {

        [SerializeField] private string nextScene;
        
        
        public IInteractable.Interact GetInteractDelegate()
        {
            return Interact;
        }

        public void Interact()
        {
            SceneManager.LoadScene(nextScene);
        }
        
        public void Exit()
        {
            
        }
    }
}