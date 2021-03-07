using Plantack.Player;
using UnityEngine;

namespace Plantack.Interactable
{
    [RequireComponent(typeof(Collider2D))]
    public class CoinIcollectable : MonoBehaviour, Icollectable
    {

        [SerializeField] private int value = 1;
        
        
        public void Collect(PlayerStats playerStats)
        {
            playerStats.Coins += value;
            Destroy(gameObject);
        }
    }
}