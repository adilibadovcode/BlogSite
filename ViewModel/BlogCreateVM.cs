namespace BlogSite.ViewModel;

public class BlogCreateVM
{
    public int Id { get; set; }
    public string Header { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public IFormFile Image { get; set; }
}
