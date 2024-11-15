namespace MusicApp.Helpers;
public class FileHelper
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

    public static string LoadAudio(string audioPath)
    {
        if (!File.Exists(audioPath))
        {
            return "404";
        }
        var bytes = File.ReadAllBytes(audioPath);
        var base64Audio = Convert.ToBase64String(bytes);
        return $"data:audio/mp3;base64,{base64Audio}";
    }



}