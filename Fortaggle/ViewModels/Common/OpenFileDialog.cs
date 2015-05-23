namespace Fortaggle.ViewModels.Common
{
    using System;
    using System.Windows.Forms;
    using CommonDialog = Microsoft.Win32.CommonDialog;
    using OpenFileDialogForms = System.Windows.Forms.OpenFileDialog;

    public class OpenFileDialog : CommonDialog
    {
        public string FileName { get; set; }

        public OpenFileDialog()
        {
            Reset();
        }

        public override void Reset()
        {
            FileName = String.Empty;
        }

        private class Win32Window : IWin32Window
        {
            private IntPtr _handle;

            public Win32Window(IntPtr handle)
            {
                _handle = handle;
            }

            public IntPtr Handle
            {
                get
                {
                    return _handle;
                }
            }
        }

        protected override bool RunDialog(IntPtr hwndOwner)
        {
            using (var ofd = new OpenFileDialogForms())
            {
                if (ofd.ShowDialog(new Win32Window(hwndOwner)) != DialogResult.OK)
                {
                    return false;
                }
                FileName = ofd.FileName;
                return true;
            }
        }
    }
}
