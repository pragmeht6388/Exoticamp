using Exoticamp.Application.Features.Events.Queries.GetEventsExport;
using System.Collections.Generic;

namespace Exoticamp.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
