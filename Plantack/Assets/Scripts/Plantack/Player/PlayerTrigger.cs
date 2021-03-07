using System;
using UnityEngine;
using Plantack.Interactable;

namespace Plantack.Player
{
    [RequireComponent(typeof(Collider2D), typeof(PlayerStats))]
    public class PlayerTrigger : MonoBehaviour
    {
        
        private const String collectableTag = "Collectable";
        private PlayerStats _playerStats;

        private void Start()
        {
            _playerStats = GetComponent<PlayerStats>();
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log($"Collision with {other}");
            if (other.gameObject.CompareTag(collectableTag))
            {
                
                Iinteractable interactable = other.gameObject.GetComponent<Iinteractable>();
                interactable.Interact(_playerStats);
            }
        }
        
    }
}