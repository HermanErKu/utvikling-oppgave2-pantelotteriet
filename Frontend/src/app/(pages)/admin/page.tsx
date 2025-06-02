"use client";

import { useEffect, useState } from "react";
import { useRouter } from "next/navigation";

export default function AdminPage() {
  const [usersData, setUsersData] = useState<any>(null);
  const router = useRouter();

  useEffect(() => {
    const storedUser = localStorage.getItem("user");
    if (!storedUser) {
      router.push("/"); // Not logged in
      return;
    }

    const user = JSON.parse(storedUser);
    if (user.role !== 1) {
      router.push("/"); // Not an admin
    }
  }, [router]);

  const getAllUsers = async () => {
    try {
      const response = await fetch("http://localhost:5000/api/user");
      if (!response.ok) {
        throw new Error("Network response was not ok");
      }
      const data = await response.json();
      setUsersData(data);
    } catch (error) {
      console.error("Failed to fetch users:", error);
    }
  };

  return (
    <div>
      <h1 className="text-2xl font-bold mb-4">Admin Dashboard</h1>
      <button
        onClick={getAllUsers}
        className="bg-blue-500 text-white px-4 py-2 rounded"
      >
        Get All Users
      </button>
      {usersData && (
        <div className="mt-4">
          <h2 className="text-xl font-semibold">Users List</h2>
          <ul className="list-disc pl-5">
            {usersData.map((user: any) => (
              <li className="flex-col" key={user.id}>
                <p>name: <strong>{user.name}</strong></p>
                <p>email: <strong>{user.email}</strong></p>
                <p>password: <strong>{user.passwordHash}</strong></p>
                <p>phone: <strong>{user.phoneNumber}</strong></p>
                <p>role: <strong>{user.role}</strong></p>
              </li>
            ))}
          </ul>
        </div>
      )}
    </div>
  );
}
