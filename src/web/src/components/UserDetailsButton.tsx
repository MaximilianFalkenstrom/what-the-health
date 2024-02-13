import { useNavigate } from "react-router";
import { Button } from "@mantine/core";

export default function UserDetailsButton() {
  const navigate = useNavigate();

  return (
    <>
      <div>
        <Button onClick={() => navigate("/user/details")}>UserDetails</Button>
      </div>
    </>
  );
}
