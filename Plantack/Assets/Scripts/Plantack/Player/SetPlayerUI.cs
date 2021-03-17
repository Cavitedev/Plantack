using UnityEngine;
using UnityEngine.UI;

namespace Plantack.Player
{
    public class SetPlayerUI : MonoBehaviour
    {
        [SerializeField] private PlayerUI[] playersUI;

        [SerializeField] private Animator animator;
        [SerializeField] private SpriteRenderer playerRenderer;
        [SerializeField] private Image jumpButton;
        [SerializeField] private Image climbButton;
        [SerializeField] private Image runButton;
        [SerializeField] private Image attackButton;

        private PlayerUI _playerUI;
        private int _playerIndex;
        private void Start()
        {
            _playerIndex = PlayerPrefs.GetInt("playerIndex", 0);
            _playerUI = playersUI[_playerIndex];
            
            
            animator.runtimeAnimatorController = _playerUI.animator;
            playerRenderer.sprite = _playerUI.defaultImage;
            jumpButton.sprite = _playerUI.jumpImage;
            climbButton.sprite = _playerUI.climbImage;
            runButton.sprite = _playerUI.runImage;
            if (attackButton != null)
                //Sin implementar
            {
                attackButton.sprite = _playerUI.attackImage;
            }
        }
    }
}