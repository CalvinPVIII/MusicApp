using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using MusicApp.Models;
using MusicApp.DTO;
using MusicApp.Helpers;
using System.Text.RegularExpressions;
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
                FolderInfo folder = GetFolderInfo(folderName, false);
                if (folder.NumberOfSongs != 0)
                {
                    folders.Add(folder);
                }
            }

            return new ApiResponseDTO { Status = "success", Data = folders };
        }
        catch (Exception ex)
        {
            return new ApiResponseDTO { Status = "error", Data = "" };

        }
    }

    [Route(HttpVerbs.Get, "/album-details")]
    public ApiResponseDTO AlbumDetails(string albumName)
    {
        try
        {
            FolderInfo folder = GetFolderInfo(albumName, true);
            return new ApiResponseDTO() { Status = "success", Data = folder };
        }
        catch (Exception ex)
        {
            return new ApiResponseDTO() { Status = "error", Data = "" };

        }
    }

    private FolderInfo GetFolderInfo(string folderPath, bool getSongData)
    {
        // for files will need to separate between songs/cover img
        string name = RemovePath(folderPath);
        string path = Path.Combine(_appDirectoryLocation, folderPath);
        string img = FileHelper.LoadImage(Path.Combine(path, "cover.png")); // change this to be more than just png
        var files = Directory.GetFiles(path);
        List<Song> songs = new List<Song>();
        foreach (var songFile in files)
        {
            Song song = new Song() { SongName = RemovePath(songFile) };
            if (getSongData)
            {
                song.SongData = FileHelper.LoadAudio(Path.Combine(path, songFile));
            }
            songs.Add(song);
        }
        var folder = new FolderInfo() { FolderName = name, FolderPath = path, CoverImg = img, NumberOfSongs = files.Count(), Songs = songs };
        return folder;
    }

    private static string RemovePath(string folderPath)
    {
        string pattern = @"(?<=\/)[^\/]+$";

        Regex regex = new Regex(pattern);
        Match match = regex.Match(folderPath);
        if (match.Success)
        {
            return match.Groups[0].Value;
        }
        else
        {
            return folderPath;
        }
    }



}