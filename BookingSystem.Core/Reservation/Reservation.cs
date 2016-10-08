namespace BookingSystem.Reservation
{
    using System;
    using Abp.Domain.Entities;

    public enum ReservationStatus
    {
        Reserve = 0,
        CheckedIn,
        CheckedOut,
        Cancelled
    }

    public class Reservation : Entity<int>
    {
        public static Reservation Create(Customer customer, Room room, DateTime checkInDate, DateTime? checkOutDate)
        {
            return new Reservation(customer.Id, room.Id, checkInDate, checkOutDate);
        }

        public int RoomId { get; private set; }

        public int CustomerId { get; private set; }

        public DateTime CheckIn { get; private set; }

        public DateTime? CheckOut { get; private set; }

        public ReservationStatus Status { get; private set; }

        protected Reservation() { }

        private Reservation(int customerId, int roomId, DateTime checkInDate, DateTime? checkOutDate)
        {
            Status = ReservationStatus.Reserve;
            CustomerId = customerId;
            RoomId = roomId;
            CheckIn = checkInDate;
            CheckOut = checkOutDate;
        }

        public void ChangeCheckOutDate(DateTime newCheckOutDate)
        {
            if (CheckIn > newCheckOutDate) throw new Exception("Impossible check out date");
            if (DateTime.Now > newCheckOutDate) throw new Exception("Impossible check out date");
            CheckOut = newCheckOutDate;
        }

        public void ChangeCheckInDate(DateTime newCheckIn)
        {
            if (newCheckIn > CheckOut) throw new Exception("Impossible check in date");
            if (DateTime.Now > newCheckIn) throw new Exception("Impossible check in date");
            CheckIn = newCheckIn;
        }

        public void CancelReservation()
        {
            Status = ReservationStatus.Cancelled;
        }

        public void CustomerCheckedIn()
        {
            Status = ReservationStatus.CheckedIn;
        }

        public void CustomerCheckedOut()
        {
            Status = ReservationStatus.CheckedOut;
        }
    }
}