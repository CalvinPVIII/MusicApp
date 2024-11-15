import { useEffect, useState } from "react";

export default function AlbumInfo() {
  const [albumData, setAlbumData] = useState();

  const fetchAlbumData = async () => {
    const albumName = "Test Album";
    const response = await fetch(`http://localhost:1234/api/album-details?albumName=${albumName}`);
    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }
    const result = await response.json();
    console.log(result);
  };

  useEffect(() => {
    fetchAlbumData();
  }, []);

  return <h1>ALBUM INFO</h1>;
}
