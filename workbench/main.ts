










// src/main.ts
import { initSidebar } from "./ui/Sidebar";
import { initHeader } from "./ui/Header";
import { initFilters } from "./ui/Filters";
import { loadCSV, setState } from "./app";

document.addEventListener("DOMContentLoaded", () => {
    initSidebar();
    initHeader();
    initFilters();

    const fileInput = document.getElementById("csv") as HTMLInputElement;

    fileInput.addEventListener("change", async (e) => {
        const file = (e.target as HTMLInputElement).files?.[0];
        if (!file) return;
        const text = await file.text();
        loadCSV(text);
    });

    // Estado inicial
    setState({ delimiter: "auto" });
});