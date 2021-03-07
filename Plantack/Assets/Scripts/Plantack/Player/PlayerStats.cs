using System;
using UnityEngine;

namespace Plantack.Player
{
    public class PlayerStats : MonoBehaviour
    {

        private int _coins;

        public int Coins
        {
            get => _coins;
            set
            {
                _coins = value;
                onCoinChange(value);
            }
        }
        
        public delegate void OnCoinChange(int newValue);

        public OnCoinChange onCoinChange;
        
        public int Health { get; set; }
        
        
        
    }
}
