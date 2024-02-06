import { useNavigate } from "react-router";
import { Button, Center } from "@mantine/core";

export default function NewFoodEntryButton() {
  const navigate = useNavigate();

  return (
    <Center>
      <Button onClick={() => navigate("/food/entry/new")}>+</Button>
    </Center>
  );
}
