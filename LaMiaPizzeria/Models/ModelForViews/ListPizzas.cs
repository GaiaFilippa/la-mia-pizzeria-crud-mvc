namespace LaMiaPizzeria.Models.ModelForViews
{
    public class ListPizzas
    {
        public string SearchString { get; set; }

        public List<Pizza> ResultArticles { get; set; }

        public ListPizzas(string searchString, List<Pizza> resultArticles)
        {
            
            SearchString = searchString;
            ResultArticles = resultArticles;
        }
    }
}
