using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using MusicApp.Models;
using MusicApp.DTO;
namespace MusicApp.Controllers;


public class HomeController : WebApiController
{
    private readonly string _appDirectoryLocation = AppDomain.CurrentDomain.BaseDirectory;
    [Route(HttpVerbs.Get, "/home")]
    public string Index()
    {
        return "Hello!";
    }

    [Route(HttpVerbs.Get, "/get-folders")]
    public ApiResponseDTO GetFolders()
    {
        try
        {

            var folderNames = Directory.GetDirectories(_appDirectoryLocation);
            List<FolderInfo> folders = new List<FolderInfo> { };
            foreach (var folderName in folderNames)
            {
                string name = folderName;
                string path = Path.Combine(_appDirectoryLocation, folderName);
                string img = Path.Combine(path, "cover.png"); // change this to be more than just png
                var files = Directory.GetFiles(path);
                var folder = new FolderInfo() { FolderName = name, FolderPath = path, CoverImg = img, NumberOfSongs = files.Count() };
                folders.Add(folder);
            }

            return new ApiResponseDTO { Status = "success", Data = folders };
        }
        catch (Exception ex)
        {
            return new ApiResponseDTO { Status = "error", Data = "" };

        }
    }

}