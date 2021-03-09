using System;
using Plantack.Interactable;
using Plantack.Player;
using UnityEngine;

namespace Plantack.Collectable
{
    [RequireComponent(typeof(Collider2D), typeof(AudioSource))]
    public class CoinIcollectable : MonoBehaviour, ICollectable
    {
        [SerializeField] private int value = 1;
        [SerializeField] private AudioSource sound;
        

        public void Collect(PlayerStats playerStats)
        {
            playerStats.Coins += value;
            sound.Play();
            Destroy(gameObject, sound.clip.length);
            
        }
    }
}