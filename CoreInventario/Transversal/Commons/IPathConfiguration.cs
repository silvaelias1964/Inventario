namespace CoreInventario.Transversal.Commons
{
    public interface IPathConfiguration
    {
        string PathAvatar { get; set; }
        string PathProductos { get; set; }
        string PathFactor1 {  get; set; }
        string PathFactor2 { get; set; }
        string PathArchivos { get; set; }
        string PathSalidas { get; set; }
    }
}