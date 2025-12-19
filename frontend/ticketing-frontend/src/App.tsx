import { useEffect } from "react";
import { api } from "./api/client";

function App() {
  useEffect(() => {
    api.get("/health")
      .then(res => {
        console.log("Backend health:", res.data);
      })
      .catch(err => {
        console.error("Backend connection error:", err);
      });
  }, []);

  return <h1>AI Ticketing System</h1>;
}

export default App;
