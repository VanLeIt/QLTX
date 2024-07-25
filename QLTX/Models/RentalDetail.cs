namespace QLTX.Models;

public class RentalDetail
{
    public int RentalId { get; set; }
    public virtual Rental? Rental { get; set; }


    public int EMotorbileId { get; set; }
    public virtual EMotorbike? EMotorbike { get; set; }

}
