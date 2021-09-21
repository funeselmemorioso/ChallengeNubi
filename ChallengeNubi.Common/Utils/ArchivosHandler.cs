using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeNubi.Common.Utils
{
    public class ArchivosHandler : IArchivosHandler
    {
        public bool GenerarCSV(String CSV, String path)
        {            
            try
            {
                File.WriteAllText(path + ".csv", CSV);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public bool GenerarJSON(String JSON, String path)
        {
            try
            {
                File.WriteAllText(path + ".json", JSON);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
