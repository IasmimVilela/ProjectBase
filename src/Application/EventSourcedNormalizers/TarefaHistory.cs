using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using TaskB3.Domain.Core.Events;

namespace TaskB3.Application.EventSourcedNormalizers
{
    public class TarefaHistory
    {
        public static IList<TarefaHistoryData> HistoryData { get; set; }

        public static IList<TarefaHistoryData> ToJavaScriptTarefaHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<TarefaHistoryData>();
            TarefaHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<TarefaHistoryData>();
            var last = new TarefaHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new TarefaHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    Descricao = string.IsNullOrWhiteSpace(change.Descricao) || change.Descricao == last.Descricao
                        ? ""
                        : change.Descricao,
                    Data = string.IsNullOrWhiteSpace(change.Data) || change.Data == last.Data
                        ? ""
                        : change.Data,
                    Status = string.IsNullOrWhiteSpace(change.Status) || change.Status == last.Status
                        ? ""
                        : change.Status.Substring(0, 10),
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void TarefaHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new TarefaHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "TarefaCreateEvent":
                        values = JsonSerializer.Deserialize<Dictionary<string, string>>(e.Data);
                        slot.Data = values["Data"];
                        slot.Status = values["Status"];
                        slot.Descricao = values["Descricao"];
                        slot.Action = "Create";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "TarefaUpdatedEvent":
                        values = JsonSerializer.Deserialize<Dictionary<string, string>>(e.Data);
                        slot.Data = values["Data"];
                        slot.Status = values["Status"];
                        slot.Descricao = values["Descricao"];
                        slot.Action = "Updated";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "TarefaRemovedEvent":
                        values = JsonSerializer.Deserialize<Dictionary<string, string>>(e.Data);
                        slot.Action = "Removed";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                }
                HistoryData.Add(slot);
            }
        }
    }
}
