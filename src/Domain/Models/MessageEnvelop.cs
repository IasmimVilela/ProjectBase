using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskB3.Domain.Models
{
    public class MessageEnvelop
    {
        public object Content { get; set; }
        public string RoutingKey { get; set; }
    }
}
