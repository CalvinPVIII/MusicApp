namespace MusicApp.Helpers;
public class ImageHelper
{
    public static string LoadImage(string imagePath)
    {
        if (!File.Exists(imagePath))
        {
            return "404";
        }
        var bytes = File.ReadAllBytes(imagePath);
        var base64Img = Convert.ToBase64String(bytes);
        return $"data:image/png;base64,{base64Img}";
    }

}