namespace ProyectoProgramWebTecnoReparo.Models
{
    public class xCategory
    {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<Category> categories { get; set; }
    }
}
