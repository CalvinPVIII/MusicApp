namespace MusicApp.Models;
public class FolderInfo
{
    public string FolderName { get; set; }
    public string FolderPath { get; set; }
    public string CoverImg { get; set; }
    public int NumberOfSongs { get; set; }
    public List<Song> Songs { get; set; }

}