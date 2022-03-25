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
    public class GetReservationFilterRequestHandler :
        IRequestHandler<GetReservationFilterRequest, List<ReservationModel>>
    {
        private RContext _context;

        public GetReservationFilterRequestHandler(RContext context)
        {
            _context = context;
        }

        public async Task<List<ReservationModel>> Handle(GetReservationFilterRequest request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var query = _context.Rezervations.Include(x => x.Members)
                .Include(x => x.Room).AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.RoomNumber))
            {
                query = query.Where(x => x.Room.Name == request.RoomNumber);
            }

            var result = query.ToList();
            var items = new List<ReservationModel>();

            foreach (var item in result)
            {
                var model = new ReservationModel
                {
                    OwnerName = item.OwnerName,
                    Id = item.Id,
                    OwnerEmail = item.OwnerEmail,
                    RezervationEnd = item.RezervationEnd,
                    RezervationStart = item.RezervationStart,
                    RoomNumber = item.Room.Name
                };
                items.Add(model);
            }


            return items;

        }
    }
}
