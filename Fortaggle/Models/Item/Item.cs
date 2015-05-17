namespace Fortaggle.Models.Item
{
    using System.Drawing;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public class Item
    {
        //--- 定数

        //--- フィールド

        //--- 静的コンストラクタ

        //--- コンストラクタ

        public Item(string name, ItemStatus status)
        {
            Name = name;
            Status = status;
        }

        public Item()
            : this(null, ItemStatus.None)
        {
        }

        //--- プロパティ

        public string Name { get; set; }

        public string FolderPath { get; set; }

        public string ExecuteFilePath { get; set; }

        public ItemStatus Status { get; set; }

        public ImageSource ExecuteFileImage
        {
            get
            {
                if (string.IsNullOrEmpty(ExecuteFilePath))
                {
                    return null;
                }
                var icon = Icon.ExtractAssociatedIcon(ExecuteFilePath);
                return System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
                    icon.Handle,
                    System.Windows.Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
            }
        }

        //--- public メソッド

        public void OpenFolder()
        {
            System.Diagnostics.Process.Start(FolderPath);
        }

        public void ExecuteFile()
        {
            System.Diagnostics.Process.Start(ExecuteFilePath);
        }

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド
    }
}
