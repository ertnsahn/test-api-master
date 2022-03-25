using System;
using System.Collections.Generic;
using System.Text;
using ErtanSahin.Web.Command.Model;
using MediatR;

namespace ErtanSahin.Web.Command.Request
{
    public class GetReservationFilterRequest : IRequest<List<ReservationModel>>
    {
        public string RoomNumber { get; set; }
    }
}
