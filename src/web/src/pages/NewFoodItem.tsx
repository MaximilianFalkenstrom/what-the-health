import { useState } from "react";
import "./css/NewFoodItem.css";
import { useNavigate } from "react-router";
import { useMutation } from "react-query";
import { useAuth0 } from "@auth0/auth0-react";

const baseUrl = import.meta.env.VITE_BACKEND_BASE_URL;

export default function NewFoodItem() {
  const { getAccessTokenSilently } = useAuth0();
  const navigate = useNavigate();

  const [foodItem, setFoodItem] = useState<FoodItem>({
    id: undefined,
    name: '',
    calories: '',
    carbohydrates: '',
    fat: '',
    protein: ''
  });

  const createFoodItem = async (newFoodItem: FoodItem) => {
    const token = await getAccessTokenSilently();
  
    if (!token) {
      throw new Error("Could not fetch token"); // TODO: Error handling
    }

    return await fetch(`${baseUrl}/api/fooditem`, {
      method: 'POST',
      headers: {
          "content-type": "application/json",
          authorization: `Bearer ${token}`,
      },
      body: JSON.stringify(newFoodItem),
  });
  }

  const mutation = useMutation((newFoodItem: FoodItem) => createFoodItem(newFoodItem));

  const handleCreate = async () => {
    const response = await mutation.mutateAsync(foodItem);

    if (response.ok) {
      const createdFoodItem: FoodItem = await response.json();

      if (createdFoodItem.id) {
        navigate(`/food/${createdFoodItem.id}`);
      }
    }
    
  };

  if (mutation.isLoading) {
    return <div>Creating new food item...</div>
  }

  return (
    <div className="form-container">
      <div>
        <label htmlFor="foodName">Food Name</label>
        <input
          id="foodName"
          type="text"
          value={foodItem.name}
          onChange={(e) => setFoodItem({...foodItem, ["name"]: e.target.value})}
        />
      </div>
      <div>
        <label htmlFor="calories">Calories</label>
        <input
          id="calories"
          type="text"
          value={foodItem.calories}
          onChange={(e) => setFoodItem({...foodItem, ["calories"]: e.target.value})}
        />
      </div>
      <div>
        <label htmlFor="carbs">Carbs</label>
        <input
          id="carbs"
          type="text"
          value={foodItem.carbohydrates}
          onChange={(e) => setFoodItem({...foodItem, ["carbohydrates"]: e.target.value})}
        />
      </div>
      <div>
        <label htmlFor="protein">Protein</label>
        <input
          id="protein"
          type="text"
          value={foodItem.protein}
          onChange={(e) => setFoodItem({...foodItem, ["protein"]: e.target.value})}
        />
      </div>
      <div>
        <label htmlFor="fat">Fat</label>
        <input
          id="fat"
          type="text"
          value={foodItem.fat}
          onChange={(e) => setFoodItem({...foodItem, ["fat"]: e.target.value})}
        />
      </div>
      <div>
        <button onClick={handleCreate}>Add food</button>
      </div>
    </div>
  );
}
