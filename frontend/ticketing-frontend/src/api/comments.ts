export async function getComments(ticketId: string) {
    const res = await fetch(
      `${import.meta.env.VITE_API_URL}/api/tickets/${ticketId}/comments`,
      {
        headers: {
          Authorization: `Bearer ${localStorage.getItem("token")}`,
        },
      }
    );
    return res.json();
  }
  
  export async function addComment(ticketId: string, content: string) {
    const res = await fetch(
      `${import.meta.env.VITE_API_URL}/api/tickets/${ticketId}/comments`,
      {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${localStorage.getItem("token")}`,
        },
        body: JSON.stringify(content),
      }
    );
    return res.json();
  }
  