using MarketPlace.Common.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MarketPlace.Common.Extentions
{
    public static class LanguageExtention
    {
        public static List<string> supportedLanguage { get; set; } = new List<string> { "tr", "en" };


        public static string GetMessageResourceValue(this string key, string lang)
        {
            return key.GetResourceValue(lang, typeof(MeesageResouce));
        }

        public static string GetAlertResourceValue(this string key, string lang)
        {
            return key.GetAlertResourceValue(lang, typeof(AlertResource));
        }

        public static string GetAlertResourceValue(this string key, string lang, Type provider = null)
        {
            if (key == null)
            {
                return "";
            }

            if (provider == null)
            {
                provider = typeof(AlertResource);
            }


            var cultureInfo = new CultureInfo(lang);

            foreach (var staticProperty in provider.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
            {
                ResourceManager resourceManager = (ResourceManager)staticProperty.GetValue(null, null);
                if (resourceManager != null)
                {
                    resourceManager.IgnoreCase = true;
                    if (resourceManager.GetString(key, cultureInfo) == null)
                    {
                        return key;
                    }
                    return resourceManager?.GetString(key, cultureInfo) ?? "";
                }
            }
            return key;
        }

        public static string GetResourceValue(this string key, string lang, Type provider = null)
        {
            if (key == null)
            {
                return "";
            }

            if (provider == null)
            {
                provider = typeof(MeesageResouce);
            }


            var cultureInfo = new CultureInfo(lang);

            foreach (var staticProperty in provider.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if (staticProperty.PropertyType == typeof(MeesageResouce))
                {
                    ResourceManager resourceManager = (ResourceManager)staticProperty.GetValue(null, null);
                    if (resourceManager != null)
                    {
                        resourceManager.IgnoreCase = true;
                        if (resourceManager.GetString(key, cultureInfo) == null)
                        {
                            return key;
                        }
                        return resourceManager?.GetString(key, cultureInfo) ?? "";
                    }
                }
            }
            return key;
        }


        public static string GetMessageResourceKey(this string key, string culture = "tr")
        {
            ResourceManager _resourceManager = MeesageResouce.ResourceManager;


            if (_resourceManager != null)
            {
                var entry = _resourceManager.GetResourceSet(new System.Globalization.CultureInfo(culture), true, true).GetString(key);


                return entry?.ToString() ?? "";
            }
            return key;
        }
    }
}
