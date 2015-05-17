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
            if (!IsExistsFile(FilePath))
            {
                return null;
            }
            var icon = Icon.ExtractAssociatedIcon(FilePath);
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
            icon.Handle,
            System.Windows.Int32Rect.Empty,
            BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
