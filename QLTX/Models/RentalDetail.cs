namespace QLTX.Models;

public class RentalDetail
{
    public int RentalId { get; set; }
    public Rental Rental { get; set; }

    public int EMotorbileId { get; set; }
	public EMotorbike EMotorbike { get; set; }
	 
     
    //public RentalDetail(int eMotorbileId, int rentalId)
    //{
    //	EMotorbileId = eMotorbileId;
    //	RentalId = rentalId;
    //}
}
