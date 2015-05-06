namespace Fortaggle.Models.ItemGroup
{
    using System.Collections.Generic;

    public class ItemGroup
    {
        //--- 定数

        //--- フィールド

        //--- 静的コンストラクタ

        //--- コンストラクタ (+2)

        public ItemGroup(string name)
        {
            Name = name;
        }

        public ItemGroup()
            : this(null)
        {
        }

        //--- プロパティ

        public string Name { get; set; }
    }
}
