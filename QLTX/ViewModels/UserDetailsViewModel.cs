namespace QLTX.ViewModels;

public class UserDetailsViewModel
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string FullName { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreationTime { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime? UpdationTime { get; set; }
    public List<string> Roles { get; set; }
}
