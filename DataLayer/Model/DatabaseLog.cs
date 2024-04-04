using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace DataLayer.Model
{
    public class DatabaseLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; } = -1;

        public string LoggerName { get; set; }

        public LogLevel LogLevel { get; set; }

        public int EventId { get; set; }

        public string LogMessage { get; set; }

        public DateTime LogDate { get; set; }
    }
}
