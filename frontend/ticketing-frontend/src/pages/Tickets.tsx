import { useEffect, useState } from "react";
import { getTickets } from "../api/ticketApi";

import "./Tickets.css";

interface Ticket {
  id: string;
  title: string;
  description: string;
  status: string;
  createdAt: string;
}

export default function Tickets() {
  const [tickets, setTickets] = useState<Ticket[]>([]);

  useEffect(() => {
    getTickets().then(res => setTickets(res.data));
  }, []);

  return (
    <div className="tickets-page">
      <h1>My Tickets</h1>

      {tickets.length === 0 && <p>No tickets yet.</p>}

      {tickets.map(t => (
        <div key={t.id} className="ticket-card">
          <h3>{t.title}</h3>
          <p>{t.description}</p>
          <span className={`status ${t.status.toLowerCase()}`}>
            {t.status}
          </span>
        </div>
      ))}
    </div>
  );
}
