using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TaskB3.Domain.Models
{
    public class DomainEvent : INotification
    {
        public Guid Id { get; set; }
        public string EvenName { get; set; }
        public string Message { get; set; }
        public DateTime PublishedAt { get; set; }

    }
}
