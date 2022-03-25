using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ErtanSahin.Web.Command.Core;
using ErtanSahin.Web.Command.Request;
using ErtanSahin.Web.Data;
using ErtanSahin.Web.Data.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ErtanSahin.Web.Command.Handler
{
    public class CreateReservationRequestHandler : IRequestHandler<CreateReservationRequest, bool>
    {
        private readonly RContext _context;

        public CreateReservationRequestHandler(RContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateReservationRequest request, CancellationToken cancellationToken)
        {
            int roomId = int.Parse(request.RoomId);
            var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == roomId, cancellationToken);

            if (room == null)
                throw new ValidationException($"room not found {request.RoomId}");

            if (!request.Members.Any())
                throw new BussinesException("must have at least 1 guest in the meeting");

            //gerekli kontrollerin yapıldığını hesaplıyorum. Daha önceden rezerasyon varmı yok mu vs.
            //Rezerve tarihi bitiş başlangıctan kücük olamaz
            var reservation = new Rezervation
            {
                OwnerEmail = request.OwnerEmail,
                OwnerName = request.OwnerName,
                RezervationStart = Convert.ToDateTime(request.ReservationStart, new CultureInfo("tr")),
                RezervationEnd = Convert.ToDateTime(request.ReservationEnd, new CultureInfo("tr")),
                Room = room
            };

            foreach (var item in request.Members)
            {
                reservation.Members.Add(new Member()
                {
                    Email = item.Email,
                    State = State.Waiting
                });
            }

            await _context.AddAsync(reservation, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return true;

        }
    }
}
