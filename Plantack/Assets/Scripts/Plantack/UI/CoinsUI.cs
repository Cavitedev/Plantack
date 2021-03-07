using Plantack.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Plantack.UI
{
    public class CoinsUI : MonoBehaviour
    {
        [SerializeField] private Text textUI;
        [SerializeField] private PlayerStats playerStats;

        private void Start()
        {
            playerStats.onCoinChange += onCoinChange;
        }

        private void onCoinChange(int value)
        {
            textUI.text = value.ToString();
        }
    }
}