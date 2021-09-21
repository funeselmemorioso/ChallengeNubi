using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeNubi.Common.Utils
{
    public interface IArchivosHandler
    {
        bool GenerarJSON(String JSON, String path);
        bool GenerarCSV(String CSV, String path);
    }
}
