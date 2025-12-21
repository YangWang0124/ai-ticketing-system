import { api } from "./client";

export const getTickets = () =>
  api.get("/api/tickets");

export const createTicket = (data: {
  title: string;
  description: string;
}) =>
  api.post("/api/tickets", data);
