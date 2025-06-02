"use client";

import { useEffect, useState } from "react";
import { redirect } from "next/navigation";

export default function Home() {
  const [user, setUser] = useState<any>(null);

  useEffect(() => {
    const storedUser = localStorage.getItem("user");
    if (!storedUser) {
      redirect("/login");
    } else {
      setUser(JSON.parse(storedUser));
    }
  }, []);



  if (!user) return <p className="text-center mt-10">Loading...</p>;

  return (
    <div className="flex flex-col items-center justify-center min-h-screen bg-gray-100">
      <div className="bg-white p-8 rounded-lg shadow-md w-full max-w-md text-center">
        <h1 className="text-2xl font-bold mb-4">Welcome, {user.name}!</h1>
        <p className="text-gray-600">User ID: {user.id}</p>
      </div>

      <div className="pt-6">
        <button onClick={() => redirect("/pant")} className="border-4 border-black p-2 rounded-xl cursor-pointer">Start å pante!</button>
      </div>

      <div className="pt-6">
        <button onClick={() => redirect("/statistikk")} className="border-4 border-black p-2 rounded-xl cursor-pointer">Sjekk din panting!</button>
      </div>


      <div className="pt-6">
        <button
          onClick={() => {
            localStorage.removeItem("user");
            window.location.reload(); // Refresh the page
          }}
          className="border-4 border-black p-2 rounded-xl cursor-pointer"
        >
          Logg ut av konto!
        </button>
      </div>
    </div>
  );
}
