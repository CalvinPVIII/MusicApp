import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "./index.css";
import App from "./App.tsx";
import AlbumInfo from "./Components/Pages/AlbumInfo.tsx";
import { BrowserRouter, Route, Routes } from "react-router-dom";

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<App />} />
        <Route path="/album/:album_name" element={<AlbumInfo />} />
      </Routes>
    </BrowserRouter>
  </StrictMode>
);
