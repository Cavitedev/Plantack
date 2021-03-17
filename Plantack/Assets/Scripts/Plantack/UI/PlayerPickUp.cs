using UnityEngine;
using UnityEngine.SceneManagement;

namespace Plantack.UI
{
    public class PlayerPickUp : MonoBehaviour
    {
        [SerializeField] private int index = 0;

        public void GoLevel()
        {
            PlayerPrefs.SetInt("playerIndex", index);
            SceneManager.LoadScene("Level_0");
        }
        
    }
}