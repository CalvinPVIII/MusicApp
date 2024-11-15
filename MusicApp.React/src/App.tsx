import { useState, useEffect } from "react";
import "./Styles/App.css";
import GetFoldersApiResponse from "./types";
import { Link } from "react-router-dom";

function App() {
  const [data, setData] = useState<GetFoldersApiResponse | null>(null);
  const [error, setError] = useState<string>();

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch("http://localhost:1234/api/get-folders");
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        const result = await response.json();
        console.log(result);
        setData(result as GetFoldersApiResponse);
      } catch (error) {
        console.error("Failed to get Data:", error);
        setError("Error Loading Data");
      }
    };
    fetchData();
  }, []);

  return (
    <>
      <div className="flex flex-wrap gap-6 justify-center p-6 bg-gray-600 object-corner rounded-xl">
        {data &&
          data.Data.map((folder) => (
            <Link className="text-gray-100" to={`/album/${folder.FolderName}`} key={folder.FolderName}>
              <p>Folder Name: {folder.FolderName}</p>
              <img src={folder.CoverImg} className="w-full h-48 object-corner rounded-xl" />
              <div className="p-4">
                <h3 className="text-lg font-bold text-gray-100">{folder.FolderName}</h3>
                <p className="text-sm text-gray-200">{folder.NumberOfSongs}</p>
              </div>
            </Link>
          ))}
      </div>
    </>
  );
}

export default App;
