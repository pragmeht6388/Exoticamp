using MyCleanProject1.Application.Features.Events.Queries.GetEventsExport;
using System.Collections.Generic;

namespace MyCleanProject1.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
