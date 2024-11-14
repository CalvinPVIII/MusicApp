import { useState, useEffect } from "react";
import "./App.css";
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
      <div>
        {data &&
          data.Data.map((folder) => (
            <Link to={`/album/${folder.FolderName}`} key={folder.FolderName}>
              <p>Folder Name: {folder.FolderName}</p>
              <img src={folder.CoverImg} />
            </Link>
          ))}
      </div>
    </>
  );
}

export default App;
