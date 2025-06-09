import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import HomePage from "./pages/HomePage";
import BookingPage from "./pages/BookingPage";

export default function App() {
  return (
    <Router>
      <div className="min-h-screen p-4 bg-gray-100">
        <nav className="mb-6 space-x-4">
          <Link to="/" className="text-blue-600 hover:underline">Home</Link>
          <Link to="/book" className="text-blue-600 hover:underline">Book a Lesson</Link>
        </nav>
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/book" element={<BookingPage />} />
        </Routes>
      </div>
    </Router>
  );
}
