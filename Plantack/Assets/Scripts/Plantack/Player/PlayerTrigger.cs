using System;
using Plantack.Collectable;
using UnityEngine;
using Plantack.Interactable;

namespace Plantack.Player
{
    [RequireComponent(typeof(Collider2D), typeof(PlayerStats))]
    public class PlayerTrigger : MonoBehaviour
    {
        
        private const String _statsColliderTag = "StatsCollider";
        private const String _interactableTag = "Interactable";
        private PlayerStats _playerStats;

        private void Start()
        {
            _playerStats = GetComponent<PlayerStats>();
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log($"Collision with {other}");
            if (other.gameObject.CompareTag(_statsColliderTag))
            {
                
                IStatsCollider iStatsCollider = other.gameObject.GetComponent<IStatsCollider>();
                iStatsCollider.StatsCollide(_playerStats);
            }else if (other.gameObject.CompareTag(_interactableTag))
            {
                IInteractable interactable = other.gameObject.GetComponent<IInteractable>();
                interactable.GetInteractDelegate().Invoke();
            }
        }
        
    }
}