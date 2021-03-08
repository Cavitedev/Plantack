using UnityEngine;
using UnityEngine.UI;

namespace Plantack.UI
{
    public class HeartUI : MonoBehaviour
    {

        public void SetActive(bool enabled)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(enabled);
            }
        }

        public Image foregroundImage;

    }
}