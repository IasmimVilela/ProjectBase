using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskB3.Domain.Models
{
    public class IntegrationCommand
    {
        public string CommandNome { get; set; }
        public string Message { get; set; }
        public DateTime PublishAt { get; set; }
    }
}
