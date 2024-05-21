using MyCleanProject1.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;

namespace MyCleanProject1.Application.Features.Orders.GetOrdersForMonth
{
    public class GetOrdersForMonthQuery : IRequest<PagedResponse<IEnumerable<OrdersForMonthDto>>>
    {
        public DateTime Date { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
