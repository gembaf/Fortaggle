/// <summary>
/// http://yunekichi.blog.so-net.ne.jp/2008-06-13
/// </summary>

namespace Fortaggle.ViewModels.Common
{
    using System;
    using System.Windows.Forms;
    using CommonDialog = Microsoft.Win32.CommonDialog;
    using FolderBrowserDialogForms = System.Windows.Forms.FolderBrowserDialog;

    public class FolderBrowserDialog : CommonDialog
    {
        public string Description { get; set; }
        public Environment.SpecialFolder RootFolder { get; set; }
        public string SelectedPath { get; set; }
        public bool ShowNewFolderButton { get; set; }

        public FolderBrowserDialog()
        {
            Reset();
        }

        public override void Reset()
        {
            Description = String.Empty;
            RootFolder = Environment.SpecialFolder.MyComputer;
            SelectedPath = String.Empty;
            ShowNewFolderButton = true;
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
            using (var fbd = new FolderBrowserDialogForms())
            {
                fbd.Description = Description;
                fbd.RootFolder = RootFolder;
                fbd.SelectedPath = SelectedPath;
                fbd.ShowNewFolderButton = ShowNewFolderButton;

                if (fbd.ShowDialog(new Win32Window(hwndOwner)) != DialogResult.OK)
                {
                    return false;
                }

                SelectedPath = fbd.SelectedPath;
                return true;
            }
        }
    }
}
