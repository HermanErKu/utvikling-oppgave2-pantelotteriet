"use client";

import { useState } from "react";
import { useRouter } from "next/navigation";

export default function LoginPage() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const router = useRouter();

  const handleLogin = async () => {
    try {
      const res = await fetch("http://localhost:5000/api/user", {
        method: "GET",
        headers: { "Content-Type": "application/json" },
      });

      if (!res.ok) {
        const err = await res.text();
        alert("Failed to fetch users: " + err);
        return;
      }

      const users = await res.json();

      // Find user by email
      const user = users.find(
        (u: any) => u.email.toLowerCase() === email.toLowerCase()
      );

      if (!user) {
        alert("No user found with this email.");
        return;
      }

      // Compare passwords (client-side)
      if (user.passwordHash !== password) {
        alert("Incorrect password.");
        return;
      }

      // Save user and redirect
      localStorage.setItem("user", JSON.stringify(user));
      router.push("/");
    } catch (error: any) {
      console.error("Login error:", error);
      alert("Network error: " + error.message);
    }
  };

  return (
    <div className="flex items-center justify-center min-h-screen bg-gray-100">
      <div className="bg-white p-8 rounded-lg shadow-md w-full max-w-md">
        <h1 className="text-2xl font-semibold mb-6 text-center">Login</h1>

        <button
          onClick={() => router.push("/signup")}
          className="cursor-pointer p-2 text-blue-600 underline mb-4 block text-center"
        >
          Create new user?
        </button>

        <div className="space-y-4">
          <input
            name="email"
            placeholder="Email"
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            className="w-full p-2 border border-gray-300 rounded"
          />
          <input
            name="password"
            placeholder="Password"
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            className="w-full p-2 border border-gray-300 rounded"
          />
        </div>

        <button
          onClick={handleLogin}
          className="w-full mt-6 bg-blue-600 text-white py-2 rounded hover:bg-blue-700"
        >
          Log In
        </button>
      </div>
    </div>
  );
}
