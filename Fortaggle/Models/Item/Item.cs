namespace Fortaggle.Models.Item
{
    using Fortaggle.Models.Common;

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

        public string Ruby { get; set; }

        public string FolderPath { get; set; }

        public string ExecuteFilePath { get; set; }

        public ItemStatus Status { get; set; }

        //--- public メソッド

        public void OpenFolder()
        {
            ExplorerManager.StartProcess(FolderPath);
        }

        public void ExecuteFile()
        {
            ExplorerManager.StartProcess(ExecuteFilePath);
        }

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド
    }
}
