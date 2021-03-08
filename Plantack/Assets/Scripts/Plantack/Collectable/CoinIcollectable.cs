using Plantack.Interactable;
using Plantack.Player;
using UnityEngine;

namespace Plantack.Collectable
{
    [RequireComponent(typeof(Collider2D))]
    public class CoinIcollectable : MonoBehaviour, ICollectable
    {

        [SerializeField] private int value = 1;
        
        
        public void Collect(PlayerStats playerStats)
        {
            playerStats.Coins += value;
            Destroy(gameObject);
        }
    }
}