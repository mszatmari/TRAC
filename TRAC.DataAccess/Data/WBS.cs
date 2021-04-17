using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRAC.DataAccess.Data
{
    public class WBS
    {
        [Key]
        public string PRJ_ID_SAP { get; set; }
        public string PRJ_CLI_NAME { get; set; }
        public string PRJ_Name { get; set; }
        public string PRJ_Year { get; set; }

    }
}
