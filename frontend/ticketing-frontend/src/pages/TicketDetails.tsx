import { useParams } from "react-router-dom";
import TicketComments from "../components/TicketComments";

export default function TicketDetails() {
  const { id } = useParams<{ id: string }>();

  if (!id) return <p>Ticket not found</p>;

  return (
    <div>
      <h1>Ticket Details</h1>

      {/* show title/description here later */}

      <TicketComments ticketId={id} />
    </div>
  );
}
