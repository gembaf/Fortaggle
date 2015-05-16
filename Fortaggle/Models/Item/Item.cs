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

        public Item(string name)
        {
            Name = name;
        }

        public Item()
            : this(null)
        {
        }

        //--- プロパティ

        public string Name { get; set; }

        public string FolderPath { get; set; }

        public string ExecuteFilePath { get; set; }

        #region ImageSource ExecuteFileImage

        private ImageSource _ExecuteFileImage;

        public ImageSource ExecuteFileImage
        {
            get
            {
                if (string.IsNullOrEmpty(ExecuteFilePath))
                {
                    return null;
                }
                if (_ExecuteFileImage == null)
                {
                    var icon = Icon.ExtractAssociatedIcon(ExecuteFilePath);
                    _ExecuteFileImage = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
                        icon.Handle,
                        System.Windows.Int32Rect.Empty,
                        BitmapSizeOptions.FromEmptyOptions());
                }
                return _ExecuteFileImage;
            }
        }

        #endregion

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド
    }
}
