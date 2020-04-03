namespace ParkApi.Models
{
  public class Pager
  {
    private const int maxPageSize = 100;
    public int pageNumber { get; set; }
    private int _pageSize = 5;
    public int pageSize 
    { 
      get { return _pageSize;}
      set
      {
        _pageSize = (value < maxPageSize) ? value : maxPageSize;
      }
    }
  }
}
