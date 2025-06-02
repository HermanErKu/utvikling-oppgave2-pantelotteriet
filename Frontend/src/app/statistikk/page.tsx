"use client";

import { useEffect, useState } from "react";

interface Pant {
  userId: number;
  pantemaskinId: number;
  pantAmount: number;
}

export default function Home() {
  const [pantData, setPantData] = useState<Pant[]>([]);
  const [userId, setUserId] = useState<number | null>(null);

  useEffect(() => {
    const storedUser = localStorage.getItem("user");
    if (!storedUser) return;

    const user = JSON.parse(storedUser);
    setUserId(user.id);

    const fetchPantData = async () => {
      try {
        const res = await fetch("http://localhost:5000/api/pant");
        if (!res.ok) {
          throw new Error("Failed to fetch pant data");
        }
        const data: Pant[] = await res.json();
        const filtered = data.filter((pant) => pant.userId === user.id);
        setPantData(filtered);
      } catch (error) {
        console.error("Error fetching pant data:", error);
      }
    };

    fetchPantData();
  }, []);

  return (
    <div className="p-4">
      <h1 className="text-2xl font-bold mb-4">My Pant Records</h1>
      {pantData.length === 0 ? (
        <p>No pant records found.</p>
      ) : (
        <ul className="space-y-2">
          {pantData.map((pant, index) => (
            <li key={index} className="border p-2 rounded shadow">
              <p><strong>Pantemaskin ID:</strong> {pant.pantemaskinId}</p>
              <p><strong>Pant Amount:</strong> {pant.pantAmount}</p>
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}
