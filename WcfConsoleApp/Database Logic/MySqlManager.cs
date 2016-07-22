using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace WcfConsoleApp.DatabaseLogic
{
    public class MySqlManager
    {
        public static async Task<bool> DoQuery(string connStr, string query)
        {
            try
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    await conn.OpenAsync();

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var fc = reader.FieldCount;
                                for (var i = 0; i < fc; i++)
                                {
                                    //Console.WriteLine("{0} {1}", reader.GetName(i), reader.GetValue(i));
                                }
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("MySqlManager: CheckDatabase Exception: {0}", ex.Message);
                return false;
            }
        }
    }
}
