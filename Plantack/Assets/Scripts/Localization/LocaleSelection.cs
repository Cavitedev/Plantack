using System.Collections.Generic;
using UnityEngine.Localization.Settings;

namespace UnityEngine.Localization.Samples
{
    public class LocaleSelection : MonoBehaviour
    {
        public List<Locale> Locales = new List<Locale>();
        
        public void English()
        {
            LocalizationSettings.SelectedLocale = Locales[0];
        }
        public void Italian()
        {
            LocalizationSettings.SelectedLocale = Locales[1];
        }
        public void Spanish()
        {
            LocalizationSettings.SelectedLocale = Locales[2];
        }
    }
}