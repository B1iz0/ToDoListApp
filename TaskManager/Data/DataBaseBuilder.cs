using System.Xml.Serialization;
using System.IO;

namespace TaskManager.Data
{
    public class DataBaseBuilder
    {
        private static string fileName = "database.xml";

        public static void loadToFile(DataBase data)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(DataBase));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                formatter.Serialize(fs, data);
            }
        }
        public static DataBase loadFromFile()
        {
            DataBase data = new DataBase();
            XmlSerializer formatter = new XmlSerializer(typeof(DataBase));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                data = (DataBase)formatter.Deserialize(fs);
            }
            return data;
        }
    }
}
