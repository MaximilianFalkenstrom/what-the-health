import { useNavigate } from "react-router";
import { Button, Center } from "@mantine/core";

export default function NewFoodItemButton() {
  const navigate = useNavigate();

  return (
    <Center>
      <Button onClick={() => navigate("/food/item/new")}>Add food item</Button>
    </Center>
  );
}
