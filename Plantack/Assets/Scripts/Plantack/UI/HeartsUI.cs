using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Plantack.UI
{
    public class HeartsUI : MonoBehaviour
    {
        [SerializeField] private HeartUI[] heartsUI;

        private List<Image> heartsForegroundList = new List<Image>();


        public void SetMaxHearts(int hearts)
        {
            while (heartsForegroundList.Count > hearts)
            {
                heartsUI[heartsForegroundList.Count-1].SetActive(false);
                heartsForegroundList.RemoveAt(heartsForegroundList.Count - 1);
            }

            while (heartsForegroundList.Count < hearts)
            {
                heartsForegroundList.Add(
                    heartsUI[heartsForegroundList.Count].foregroundImage);
                heartsUI[heartsForegroundList.Count-1].SetActive(true);
            }
            
            
        }

        public void UpdateHealth(float value)
        {
            foreach (Image heartImage in heartsForegroundList)
            {
                heartImage.fillAmount = Math.Min(value, 1.0f);
                value = Math.Max(0, value - 1);
            }
        }
    }
}