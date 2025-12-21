import { useState } from "react";
import { createTicket } from "../api/ticketApi";
import { useNavigate } from "react-router-dom";
import "./CreateTicket.css";

export default function CreateTicket() {
  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");
  const navigate = useNavigate();

  const submit = async () => {
    await createTicket({ title, description });
    navigate("/tickets");
  };

  return (
    <div className="create-ticket">
      <h1>Create Ticket</h1>

      <input
        placeholder="Title"
        value={title}
        onChange={e => setTitle(e.target.value)}
      />

      <textarea
        placeholder="Description"
        value={description}
        onChange={e => setDescription(e.target.value)}
      />

      <button onClick={submit}>Submit</button>
    </div>
  );
}
