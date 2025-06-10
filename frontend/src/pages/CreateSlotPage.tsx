import { useState } from "react";
import axios from "axios";

export default function AddSlotPage() {
  const [slotTime, setSlotTime] = useState("");
  const [message, setMessage] = useState("");

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    try {
      await axios.post("https://drivinglessons-bookingsystem.onrender.com/api/bookings/add", slotTime, {
        headers: { "Content-Type": "application/json" }
      });
      setMessage("✅ Slot added successfully.");
      setSlotTime("");
    } catch {
      setMessage("❌ Failed to add slot.");
    }
  };

  return (
    <div className="p-4">
      <h1 className="text-xl font-bold mb-4">Add New Slot</h1>
      <form onSubmit={handleSubmit}>
        <input
          type="datetime-local"
          value={slotTime}
          onChange={(e) => setSlotTime(e.target.value)}
          className="border px-2 py-1 mr-2"
        />
        <button type="submit" className="bg-blue-500 text-white px-3 py-1 rounded">
          Add Slot
        </button>
      </form>
      {message && <p className="mt-4">{message}</p>}
    </div>
  );
}
