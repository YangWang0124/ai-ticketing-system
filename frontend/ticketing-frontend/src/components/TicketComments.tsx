import { useEffect, useState } from "react";
import { getComments, addComment } from "../api/comments";

export default function TicketComments({ ticketId }: { ticketId: string }) {
  const [comments, setComments] = useState<any[]>([]);
  const [text, setText] = useState("");

  useEffect(() => {
    getComments(ticketId).then(setComments);
  }, [ticketId]);

  async function submit() {
    if (!text.trim()) return;
    const newComment = await addComment(ticketId, text);
    setComments([...comments, newComment]);
    setText("");
  }

  return (
    <div>
      <h3>Conversation</h3>

      {comments.map(c => (
        <div key={c.id} style={{ marginBottom: 12 }}>
          <strong>{c.createdByRole}</strong> · {c.createdBy}
          <div>{c.content}</div>
        </div>
      ))}

      <textarea
        value={text}
        onChange={e => setText(e.target.value)}
        placeholder="Write a reply..."
      />
      <button onClick={submit}>Send</button>
    </div>
  );
}
