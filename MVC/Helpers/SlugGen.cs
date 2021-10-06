namespace MVC.Helpers
{
    public class SlugGen
    {
        public static string GenerateBookSlug(string title = "")
        {
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title.Replace(" ", "-");
        }
    }
}