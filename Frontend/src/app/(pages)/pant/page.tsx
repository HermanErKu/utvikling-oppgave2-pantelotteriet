"use client";

import { useEffect, useState } from "react";

export default function PantingPage() {
  const [pantemaskiner, setPantemaskiner] = useState<any[]>([]);
  const [selectedMachineId, setSelectedMachineId] = useState<number | null>(null);
  const [pantId, setPantId] = useState<number | null>(null);
  const [barcode, setBarcode] = useState("");
  const [barcodeList, setBarcodeList] = useState<number[]>([]);
  const [userId, setUserId] = useState<number | null>(null);

  useEffect(() => {
    const fetchPantemaskiner = async () => {
      const res = await fetch("http://localhost:5000/api/pantemaskin");
      const data = await res.json();
      setPantemaskiner(data);
    };

    const storedUser = localStorage.getItem("user");
    if (storedUser) {
      const user = JSON.parse(storedUser);
      setUserId(user.id);
    }

    fetchPantemaskiner();
  }, []);

  const startPantSession = async () => {
    if (!userId || selectedMachineId === null) return;

    const payload = {
      userId,
      pantemaskinId: selectedMachineId,
      pantAmount: 0, // Will accumulate later
    };

    const res = await fetch("http://localhost:5000/api/pant", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(payload),
    });

    if (res.ok) {
      const data = await res.json();
      setPantId(data.id); // Assume API returns created pant record with `id`
    } else {
      alert("Failed to start pant session.");
    }
  };

  const submitBarcode = async () => {
    if (!userId || !pantId || !selectedMachineId || !barcode) return;

    const payload = {
      userId,
      pantId,
      pantemaskinId: selectedMachineId,
      lotteriId: 0, // Or provide logic if there's a specific lottery
      barcode: Number(barcode),
    };

    const res = await fetch("http://localhost:5000/api/pantelotterilodd", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(payload),
    });

    if (res.ok) {
      setBarcodeList((prev) => [...prev, Number(barcode)]);
      setBarcode("");
    } else {
      alert("Failed to submit barcode.");
    }
  };

  return (
    <div className="p-6 max-w-xl mx-auto">
      <h1 className="text-2xl font-bold mb-4">Start Panting</h1>

      {!pantId ? (
        <div className="space-y-4">
          <label className="block">
            <span className="font-semibold">Select Pantemaskin:</span>
            <select
              value={selectedMachineId ?? ""}
              onChange={(e) => setSelectedMachineId(Number(e.target.value))}
              className="w-full p-2 border border-gray-300 rounded mt-1"
            >
              <option value="">-- Select --</option>
              {pantemaskiner.map((pm) => (
                <option key={pm.id} value={pm.id}>
                  {pm.name} (Area: {pm.area})
                </option>
              ))}
            </select>
          </label>

          <button
            onClick={startPantSession}
            className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700"
          >
            Start Pant Session
          </button>
        </div>
      ) : (
        <div className="space-y-4">
          <h2 className="text-xl font-semibold">Panting at Machine #{selectedMachineId}</h2>

          <label className="block">
            <span className="font-semibold">Enter Barcode:</span>
            <input
              type="number"
              value={barcode}
              onChange={(e) => setBarcode(e.target.value)}
              className="w-full p-2 border border-gray-300 rounded mt-1"
              placeholder="Scan or type barcode"
            />
          </label>

          <button
            onClick={submitBarcode}
            className="bg-green-600 text-white px-4 py-2 rounded hover:bg-green-700"
          >
            Submit Barcode
          </button>

          <div className="mt-6">
            <h3 className="font-semibold">Submitted Barcodes:</h3>
            <ul className="list-disc pl-5 mt-2">
              {barcodeList.map((code, index) => (
                <li key={index}>#{code}</li>
              ))}
            </ul>
          </div>
        </div>
      )}
    </div>
  );
}
