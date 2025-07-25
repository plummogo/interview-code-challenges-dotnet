namespace OneBeyond.Core.Dtos
{
    /// <summary>
    /// DTO for reservation status.
    /// </summary>
    public class ReservationStatusDto
    {
        /// <summary>
        /// Gets or sets the position of the item in the queue (1 = next in queue).
        /// </summary>
        public int PositionInQueue { get; set; }

        /// <summary>
        /// Gets or sets the estimated date when the item will become available.
        /// </summary>
        public DateTime? EstimatedAvailableDate { get; set; }
    }
}
