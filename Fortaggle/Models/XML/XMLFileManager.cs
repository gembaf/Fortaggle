namespace Fortaggle.Models.XML
{
    using System.IO;
    using System.Xml.Serialization;

    public static class XMLFileManager
    {
        //--- 定数

        private static readonly string DataPath = Directory.GetCurrentDirectory() + @"\Data\";

        //--- フィールド

        //--- 静的コンストラクタ

        static XMLFileManager()
        {
            if (!Directory.Exists(DataPath))
            {
                Directory.CreateDirectory(DataPath);
            }
        }

        //--- private メソッド

        //--- static メソッド

        public static T ReadXml<T>(string fileName) where T : new()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StreamReader stream;
            T obj;
            try
            {
                stream = new StreamReader(DataPath + fileName);
                obj = (T)serializer.Deserialize(stream);
                stream.Close();
            }
            catch (System.Exception)
            {
                obj = new T();
            }
            return obj;
        }

        public static void WriteXml<T>(string fileName, T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StreamWriter stream = new StreamWriter(DataPath + fileName);
            serializer.Serialize(stream, obj);
            stream.Close();
        }
    }
}