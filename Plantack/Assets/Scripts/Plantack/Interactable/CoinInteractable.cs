using Plantack.Player;
using UnityEngine;

namespace Plantack.Interactable
{
    [RequireComponent(typeof(Collider2D))]
    public class CoinInteractable : MonoBehaviour, Iinteractable
    {

        [SerializeField] private int value = 1;
        
        
        public void Interact(PlayerStats playerStats)
        {
            playerStats.Coins += value;
            Destroy(gameObject);
        }
    }
}