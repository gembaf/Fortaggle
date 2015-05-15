namespace Fortaggle.Models.ItemGroup
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
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

        public ImageSource ExecuteFileImage
        {
            get
            {
                if (string.IsNullOrEmpty(ExecuteFilePath))
                {
                    return new BitmapImage();
                }
                var icon = Icon.ExtractAssociatedIcon(ExecuteFilePath);
                var bmpSrc = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
                    icon.Handle,
                    System.Windows.Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
                return bmpSrc;
            }
        }

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド
    }
}
