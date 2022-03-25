using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace ErtanSahin.Web.Command.Request
{
    public class CreateReservationRequest : IRequest<bool>
    {
        public string OwnerName { get; set; }
        public string RoomId{ get; set; }
        public string ReservationStart { get; set; }
        public string ReservationEnd { get; set; }
        public List<Member> Members { get; set; } = new List<Member>();
        public string OwnerEmail { get; set; }

        public class Member
        {
            public string Email { get; set; }
        }
    }
}
