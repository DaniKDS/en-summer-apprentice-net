namespace TMS.API.Models.Dto
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int TicketCategoryId { get; set; }
        public DateTime? OrderedAt { get; set; }
        public int NumberOfTickets { get; set; }

        public  Customer? Customer { get; set; }

        public virtual TicketCategory? TicketCategory { get; set; }

    }
}
