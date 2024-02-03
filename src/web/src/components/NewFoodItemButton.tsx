import { useNavigate } from "react-router";
import './css/NewFoodItemButton.css';

export default function NewFoodItemButton() {
  const navigate = useNavigate();

  return (
    <div className="newFoodItem">
      <button onClick={() => navigate("/food/new")}>+</button>
    </div>
  );
}
