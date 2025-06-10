import { useEffect, useState } from "react";
import axios from "axios";

type Booking = {
  id: string;
  slotTime: string;
  userId: string;
  isConfirmed: boolean;
};

export default function AdminPage() {
  const [bookings, setBookings] = useState<Booking[]>([]);
  const [loading, setLoading] = useState(true);

useEffect(() => {
  axios
    .get<Booking[]>("https://drivinglessons-bookingsystem.onrender.com/api/bookings/all")
    .then(res => {
      setBookings(res.data);
      setLoading(false);
    })
    .catch(() => setLoading(false));
}, []);

  const cleanupHolds = async () => {
    await axios.post("https://drivinglessons-bookingsystem.onrender.com/api/bookings/cleanup");
    alert("Expired holds cleaned up.");
  };

  return (
    <div className="p-4">
      <h1 className="text-2xl font-bold mb-4">Admin - All Bookings</h1>
      <button
        onClick={cleanupHolds}
        className="mb-4 px-4 py-2 bg-red-500 text-white rounded"
      >
        Cleanup Expired Holds
      </button>

      {loading ? (
        <p>Loading bookings...</p>
      ) : (
        <table className="w-full border">
          <thead>
            <tr>
              <th className="border px-2 py-1">Slot Time</th>
              <th className="border px-2 py-1">User</th>
              <th className="border px-2 py-1">Confirmed</th>
            </tr>
          </thead>
          <tbody>
            {bookings.map(b => (
              <tr key={b.id}>
                <td className="border px-2 py-1">{new Date(b.slotTime).toLocaleString()}</td>
                <td className="border px-2 py-1">{b.userId}</td>
                <td className="border px-2 py-1">{b.isConfirmed ? "✅" : "⏳"}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}
