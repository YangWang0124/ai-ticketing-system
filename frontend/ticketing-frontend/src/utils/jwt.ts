import {jwtDecode} from "jwt-decode";

interface JwtPayload {
  email?: string;
  "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"?: string;
}

export function getUserRole(): string | null {
  const token = localStorage.getItem("jwt_token");
  if (!token) return null;

  const decoded = jwtDecode<JwtPayload>(token);

  return (
    decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] ||
    null
  );
}
