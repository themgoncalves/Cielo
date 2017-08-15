namespace Cielo.Extensions
{
    public static class UrlExtesions
    {
        public static string CleanPathUrl(this string path, string host)
        {
            string cleanPathUrl = string.Empty;

            if (host.EndsWith("/"))
            {
                cleanPathUrl = (path.StartsWith("/") ? path.Substring(1, path.Length - 1) : path);
            }
            else
            {
                cleanPathUrl = (!path.StartsWith("/") ? "/" + path : path);
            }

            return cleanPathUrl;
        }

        public static string CombineUrl(this string host, string path)
        {
            string combinedUrl = string.Empty;

            if (host.EndsWith("/"))
            {
                combinedUrl = host + (path.StartsWith("/") ? path.Substring(1, path.Length - 1) : path);
            }
            else
            {
                combinedUrl = host + (!path.StartsWith("/") ? "/" + path : path);
            }

            return combinedUrl;
        }
    }
}
