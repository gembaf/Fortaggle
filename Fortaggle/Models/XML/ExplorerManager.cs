namespace Fortaggle.Models.XML
{
    using System.IO;

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
    }
}
