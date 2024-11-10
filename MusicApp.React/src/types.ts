export interface MusicFolder {
  FolderName: string;
  FolderPath: string;
  CoverImg: string;
}

export default interface GetFoldersApiResponse {
  Status: string;
  Data: MusicFolder[];
}
