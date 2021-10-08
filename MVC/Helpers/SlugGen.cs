namespace MVC.Helpers
{
    public class SlugGen
    {
        public static string GenerateSlug(string title = "")
        {
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title.Replace(" ", "-");
        }
    }
}