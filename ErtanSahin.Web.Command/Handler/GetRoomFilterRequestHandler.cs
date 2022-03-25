using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ErtanSahin.Web.Command.Model;
using ErtanSahin.Web.Command.Request;
using ErtanSahin.Web.Data.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ErtanSahin.Web.Command.Handler
{
    public class GetRoomFilterRequestHandler : IRequestHandler<GetRoomFilterRequest, List<RoomModel>>
    {
        private readonly RContext _context;
        public GetRoomFilterRequestHandler(RContext context)
        {
            _context = context;
        }
        public async Task<List<RoomModel>> Handle(GetRoomFilterRequest request, CancellationToken cancellationToken)
        {
            var rooms = await _context.Rooms.ToListAsync(cancellationToken);
            return rooms.Select(x => new RoomModel()
            {
                Name = x.Name,
                Id = x.Id
            }).ToList();

        }
    }
}
