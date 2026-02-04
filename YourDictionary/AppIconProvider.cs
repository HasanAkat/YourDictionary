using System;
using System.Drawing;
using System.Windows.Forms;

namespace YourDictionary
{
    internal static class AppIconProvider
    {
        private static Icon? _cachedIcon;

        public static Icon GetAppIcon()
        {
            if (_cachedIcon == null)
            {
                _cachedIcon = Icon.ExtractAssociatedIcon(Application.ExecutablePath) ?? SystemIcons.Application;
            }

            return (Icon)_cachedIcon.Clone();
        }
    }
}
