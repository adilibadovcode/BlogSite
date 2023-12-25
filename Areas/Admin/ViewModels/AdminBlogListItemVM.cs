namespace BlogSite.Areas.Admin.ViewModels;

public class AdminBlogListItemVM
{
    public int? Id { get; set; }
    public string? Header { get; set; }
    public string? Author { get; set; }
    public string? Description { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? Image { get; set; }
}
