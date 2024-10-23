

namespace App.Utility
{
    public static class ConexionDB
    {
        public static string RutaDB(string NombreDB)
        {
            string RutaDB = string.Empty;

            if(DeviceInfo.Platform == DevicePlatform.Android)
            {
                RutaDB = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                RutaDB = Path.Combine(RutaDB, NombreDB);
            } 
            else if(DeviceInfo.Platform == DevicePlatform.iOS)
            {
                RutaDB = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                RutaDB = Path.Combine(RutaDB,"..","Library",NombreDB);
            }

            return RutaDB;
        } 

    }
}
