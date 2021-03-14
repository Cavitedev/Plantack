using System;
using Plantack.Management;
using Plantack.Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Plantack.Collectable
{
    [RequireComponent(typeof(Collider2D))]
    public class CoinIStatsCollider : MonoBehaviour, IStatsCollider
    {
        [SerializeField] private int value = 1;
        [SerializeField] private AudioClip sound;
        [SerializeField] private float pitch = 1;
        [SerializeField] private float randomPitchAdd = 0.01f;
        

        public void StatsCollide(PlayerStats playerStats)
        {
            playerStats.Coins += value;
            float currentPitch = pitch + Random.Range(-1, 1) * randomPitchAdd;
            AudioManager.instance.PlaySound(sound, transform.position, currentPitch);
            Destroy(gameObject);
            
        }
    }
}