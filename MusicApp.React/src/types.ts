export interface MusicFolder {
  FolderName: string;
  FolderPath: string;
  CoverImg: string;
  NumberOfSongs: number;
}

export default interface GetFoldersApiResponse {
  Status: string;
  Data: MusicFolder[];
}

export interface Song {
  SongName: string;
  SongData?: string;
}
