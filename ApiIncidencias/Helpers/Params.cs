namespace ApiIncidencias.Helpers;

public class Params
{
    private int _pageSize = 5;
    private const int MaxPageSize = 50;
    private int _pageIndex = 1;
    private string _search = String.Empty;
    public int pageSize{
        get => _pageSize;
        set => _pageSize = value > MaxPageSize? MaxPageSize : value;
    }
    public int pageIndex{
        get => _pageIndex;
        set => _pageIndex = (value > MaxPageSize)? MaxPageSize : value;
    }
    public string? search{
        get => _search;
        set => _search = (!String.IsNullOrEmpty(value)) ? value.ToLower() : "";
    }
}
