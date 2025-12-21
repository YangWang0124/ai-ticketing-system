import {jwtDecode} from "jwt-decode";

interface JwtPayload {
  role: string;
  email: string;
}

export function getUserRole(): string | null {
  const token = localStorage.getItem("jwt_token");
  if (!token) return null;

  const decoded = jwtDecode<JwtPayload>(token);
  return decoded.role;
}
