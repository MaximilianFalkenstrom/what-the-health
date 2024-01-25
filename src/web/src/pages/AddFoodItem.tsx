import { useState } from "react";
import "./css/AddFoodItem.css";
import { useAuth0 } from "@auth0/auth0-react";
import { useNavigate } from "react-router";

export default function AddFoodItem() {
  const { getAccessTokenSilently } = useAuth0();
  const navigate = useNavigate();

  const [foodName, setFoodName] = useState("");
  const [calories, setCalories] = useState("");
  const [carbs, setCarbs] = useState("");
  const [protein, setProtein] = useState("");
  const [fat, setFat] = useState("");

  const handleCreate = async () => {
    const token = await getAccessTokenSilently();

    if (!token) {
      console.log("Could not fetch token");
      return;
    }

    const result = await fetch("https://localhost:7129/api/fooditem", {
      method: "POST",
      headers: {
        "content-type": "application/json",
        authorization: `Bearer ${token}`,
      },
      credentials: "include",
      body: JSON.stringify({
        name: foodName,
        calories: calories,
        carbohydrates: carbs,
        protein: protein,
        fat: fat,
      }),
    });

    if (!result.ok) {
      console.log("Could not add food!");
      return;
    }

    const { id } = await result.json();
    navigate(`/food/${id}`);
  };

  return (
    <div className="form-container">
      <div>
        <label htmlFor="foodName">Food Name</label>
        <input
          id="foodName"
          type="text"
          value={foodName}
          onChange={(e) => setFoodName(e.target.value)}
        />
      </div>
      <div>
        <label htmlFor="calories">Calories</label>
        <input
          id="calories"
          type="text"
          value={calories}
          onChange={(e) => setCalories(e.target.value)}
        />
      </div>
      <div>
        <label htmlFor="carbs">Carbs</label>
        <input
          id="carbs"
          type="text"
          value={carbs}
          onChange={(e) => setCarbs(e.target.value)}
        />
      </div>
      <div>
        <label htmlFor="protein">Protein</label>
        <input
          id="protein"
          type="text"
          value={protein}
          onChange={(e) => setProtein(e.target.value)}
        />
      </div>
      <div>
        <label htmlFor="fat">Fat</label>
        <input
          id="fat"
          type="text"
          value={fat}
          onChange={(e) => setFat(e.target.value)}
        />
      </div>
      <div>
        <button onClick={handleCreate}>Add food</button>
      </div>
    </div>
  );
}
