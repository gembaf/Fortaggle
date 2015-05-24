namespace Fortaggle.Models.Common
{
    using System.Drawing;
    using System.IO;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public static class ExplorerManager
    {
        //--- 定数

        //--- フィールド

        //--- 静的コンストラクタ

        //--- private メソッド

        //--- static メソッド

        public static bool IsExistsDirectory(string folderPath)
        {
            return Directory.Exists(folderPath);
        }

        public static bool IsExistsFile(string filePath)
        {
            return File.Exists(filePath);
        }

        public static void StartProcess(string path)
        {
            System.Diagnostics.Process.Start(path);
        }

        public static ImageSource GetIconImage(string FilePath)
        {
            Bitmap bmp;

            if (!IsExistsFile(FilePath))
            {
                bmp = Properties.Resources.ResourceManager.GetObject("NoImage") as Bitmap;
            }
            else
            {
                bmp = ShellEx.ShellEx.GetBitmapFromFilePath(FilePath, ShellEx.ShellEx.IconSizeEnum.LargeIcon48);
            }

            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                bmp.GetHbitmap(),
                System.IntPtr.Zero,
                System.Windows.Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
