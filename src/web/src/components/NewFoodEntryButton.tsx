import { useNavigate } from "react-router";
import './css/NewFoodEntryButton.css';

export default function NewFoodEntryButton() {
  const navigate = useNavigate();

  return (
    <div className="newFoodEntry">
      <button onClick={() => navigate("/food/entry/new")}>+</button>
    </div>
  );
}
