using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WPFTutorial.Model;

namespace WPFTutorial.Exceptions
{
    public class ReservationConflictException : Exception
    {
        public Reservation ExitingReservation { get; }
        public Reservation IncommingReservation { get; }
        public ReservationConflictException(Reservation exitingReservation, Reservation incommingReservation)
        {
            ExitingReservation = exitingReservation;
            IncommingReservation = incommingReservation;
        }

        public ReservationConflictException(string message, Reservation exitingReservation = null, Reservation incommingReservation = null) : base(message)
        {
            ExitingReservation = exitingReservation;
            IncommingReservation = incommingReservation;
        }

        public ReservationConflictException(string message, Exception innerException, Reservation exitingReservation, Reservation incommingReservation) : base(message, innerException)
        {
            ExitingReservation = exitingReservation;
            IncommingReservation = incommingReservation;
        }

        protected ReservationConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
