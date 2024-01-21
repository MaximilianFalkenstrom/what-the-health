import { useNavigate } from "react-router";

export default function AddFoodItemButton() {
  const navigate = useNavigate();

  return (
    <div className="addFoodItem">
      <button onClick={() => navigate("/food/new")}>+</button>
    </div>
  );
}
