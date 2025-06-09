import { useEffect, useState } from "react";
import axios from "axios";

type Slot = {
  id: number;
  dateTime: string;
  isHeld: boolean;
};

export default function BookingPage() {
  const [slots, setSlots] = useState<Slot[]>([]);
  const [loading, setLoading] = useState(true);

    useEffect(() => {
    axios.get<Slot[]>("http://localhost:5000/api/bookings/slots")
        .then(res => {
        setSlots(res.data);
        setLoading(false);
        })
        .catch(() => setLoading(false));
    }, []);

  const bookSlot = (slotId: number) => {
    axios.post("http://localhost:5000/api/bookings", { slotId })
      .then(() => alert("Booked successfully!"))
      .catch(() => alert("Failed to book."));
  };

  if (loading) return <p>Loading slots...</p>;

  return (
    <div>
      <h2 className="text-xl font-semibold mb-4">Available Slots</h2>
      <ul className="space-y-2">
        {slots.map(slot => (
          <li key={slot.id} className="bg-white p-4 rounded shadow flex justify-between items-center">
            <span>{new Date(slot.dateTime).toLocaleString()}</span>
            <button
              className="px-3 py-1 bg-blue-500 text-white rounded"
              onClick={() => bookSlot(slot.id)}
              disabled={slot.isHeld}
            >
              {slot.isHeld ? "Held" : "Book"}
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
}
