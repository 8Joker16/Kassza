using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassza.Resources
{
    static class FirstTime
    {
        /// <summary>
        /// <para>Checks the Registry for first time run of the application.</para>
        /// </summary>
        /// <returns>
        /// <para>Returns "true" if this was the first run</para>
        /// <para>Otherwise returns "false".</para>
        /// </returns>
        public static bool CheckFirstTimeRun()
        {
            return CheckKey();
        }

        /// <summary>
        /// Checks the Registry for the first time run of the application.
        /// </summary>
        /// <returns>
        /// <para>Returns "1" if this was the first run</para>
        /// <para>Otherwise returns "0".</para>
        /// </returns>
        private static bool CheckKey()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Kassza");
            string keyValue = "";
            if (key != null)
                keyValue = (string)key.GetValue(@"SOFTWARE\Kassza");
            if (keyValue == null || keyValue == "0")
                return false;
            else
                return true;
        }
        /// <summary>
        /// Sets a key with a name "FirstTimeRun" and value of "1"
        /// if this was the first time run of the application.
        /// </summary>
        private static void SetKey()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Kassza");
            key.SetValue("FirstTimeRun", "1", RegistryValueKind.String);
            key.Close();
        }
    }
}
