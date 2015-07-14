namespace Fortaggle.Models.Item
{
    using Fortaggle.Models.Common;
    using System;

    public class Item
    {
        //--- 定数

        private static readonly DateTime defaultExecutedAt = new DateTime(1, 1, 1);

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

        public string Ruby { get; set; }

        public string FolderPath { get; set; }

        public string ExecuteFilePath { get; set; }

        public DateTime ExecutedAt { get; set; }

        public ItemStatus Status { get; set; }

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド

        public static bool EqualToDefaultExecutedAt(DateTime dateTime)
        {
            return dateTime.Equals(defaultExecutedAt);
        }
    }
}
