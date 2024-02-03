import { useNavigate } from "react-router";
import './css/NewFoodItemButton.css';

export default function NewFoodItemButton() {
  const navigate = useNavigate();

  return (
    <div className="newFoodItem">
      <button onClick={() => navigate("/food/item/new")}>Add food item</button>
    </div>
  );
}
