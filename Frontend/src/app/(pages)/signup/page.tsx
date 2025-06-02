"use client";

import { useState } from "react";
import { useRouter } from "next/navigation";

export default function LoginPage() {
  const [formData, setFormData] = useState({
    name: "",
    email: "",
    phoneNumber: "",
    passwordHash: "",
    role: 0,
  });

  const router = useRouter();

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => {
    const { name, value } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: name === "role" ? Number(value) : value,
    }));
  };

  const handleSubmit = async () => {
    try {
      const payload = {
        ...formData,
        pantedItems: [],
        lotteryTickets: [],
        wonLotteries: [],
      };

      const res = await fetch("http://localhost:5000/api/user", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(payload),
      });

      if (res.ok) {
        const user = await res.json();
        localStorage.setItem("user", JSON.stringify(user));
        router.push("/");
      } else {
        const errText = await res.text();
        alert("Failed to create user: " + errText);
      }
    } catch (error: any) {
      console.error("Network error:", error);
      alert("Network error: " + error.message);
    }
  };

  return (
    <div className="flex items-center justify-center min-h-screen bg-gray-100">
      <div className="bg-white p-8 rounded-lg shadow-md w-full max-w-md">
        <h1 className="text-2xl font-semibold mb-6 text-center">Create User</h1>

        <div className="space-y-4">
          <input
            name="name"
            placeholder="Name"
            value={formData.name}
            onChange={handleChange}
            className="w-full p-2 border border-gray-300 rounded"
          />
          <input
            name="email"
            placeholder="Email"
            type="email"
            value={formData.email}
            onChange={handleChange}
            className="w-full p-2 border border-gray-300 rounded"
          />
          <input
            name="phoneNumber"
            placeholder="Phone Number"
            value={formData.phoneNumber}
            onChange={handleChange}
            className="w-full p-2 border border-gray-300 rounded"
          />
          <input
            name="passwordHash"
            placeholder="Password"
            type="password"
            value={formData.passwordHash}
            onChange={handleChange}
            className="w-full p-2 border border-gray-300 rounded"
          />
          <select
            name="role"
            value={formData.role}
            onChange={handleChange}
            className="w-full p-2 border border-gray-300 rounded"
          >
            <option value={0}>User</option>
            <option value={1}>Admin</option>
          </select>
        </div>

        <button
          onClick={handleSubmit}
          className="w-full mt-6 bg-blue-600 text-white py-2 rounded hover:bg-blue-700"
        >
          Create Account
        </button>
      </div>
    </div>
  );
}
