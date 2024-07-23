using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yListesiMaui_SQLite
{
    public static class Constants
    {
        ///<summary>
        ///Create: Bağlantı, yoksa veritabanı dosyasını otomatik olarak oluşturur.
        ///NoMutex: Bağlantı çok iş parçacıklı modda açılır.
        ///PrivateCache: Bağlantı, etkin olsa bile paylaşılan önbelleğe katılmaz.
        ///ReadWrite: Bağlantı verileri okuyabilir ve yazabilir.
        ///SharedCache: Bağlantı, etkinse paylaşılan önbelleğe katılır.
        ///ProtectionComplete: Cihaz kilitliyken dosya şifrelenir ve erişilemez.
        ///ProtectionCompleteUnlessOpen: Dosya açılana kadar şifrelenir, ancak kullanıcı cihazı kilitlese bile erişilebilir.
        ///ProtectionCompleteUntilFirstUserAuthentication: Kullanıcı önyüklenip cihazın kilidini açana kadar dosya şifrelenir.
        ///ProtectionNone: Veritabanı dosyası şifrelenmemiş.
        /// </summary> 

        public const string DatabaseFilename = "TodoSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}
