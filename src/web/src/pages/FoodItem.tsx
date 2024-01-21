import { useParams } from "react-router";

export default function FoodItem() {
  const { id } = useParams();

  return <div>Your new food item has id {id}!</div>;
}
