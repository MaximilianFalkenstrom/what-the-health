import { useState } from "react";
import "./css/NewFoodEntry.css";
import { useNavigate } from "react-router";
import { useMutation, useQuery } from "react-query";
import { useAuth0 } from "@auth0/auth0-react";

const baseUrl = import.meta.env.VITE_BACKEND_BASE_URL;

export default function NewFoodEntry() {
  const { getAccessTokenSilently } = useAuth0();
  const navigate = useNavigate();

  const [foodEntry, setFoodEntry] = useState<FoodEntry>({
    id: undefined,
    foodItemId: '',
    amount: 0,
    date: '',
    foodItem: null
  });

  const createFoodEntry = async (newFoodEntry: FoodEntry) => {
    const token = await getAccessTokenSilently();
  
    if (!token) {
      throw new Error("Could not fetch token"); // TODO: Error handling
    }

    return await fetch(`${baseUrl}/api/foodentry`, {
      method: 'POST',
      headers: {
          "content-type": "application/json",
          authorization: `Bearer ${token}`,
      },
      body: JSON.stringify(newFoodEntry),
  });
  }

  const mutation = useMutation((newFoodEntry: FoodEntry) => createFoodEntry(newFoodEntry));

  const handleCreate = async () => {
    const response = await mutation.mutateAsync(foodEntry);

    if (response.ok) {
      const createdFoodEntry: FoodEntry = await response.json();

      if (createdFoodEntry.id) {
        navigate(`/food/entry/${createdFoodEntry.id}`);
      }
    }
  };

  const fetchFoodItems = async (): Promise<FoodItem[]> => {
    const token = await getAccessTokenSilently();

    if (!token) {
      throw new Error("Could not fetch token"); // TODO: Error handling
    }

    return await fetch(`${baseUrl}/api/fooditem`, {
      method: 'GET',
      headers: {
        "content-type": "application/json",
        authorization: `Bearer ${token}`,
      },
    }).then(res => res.json() as Promise<FoodItem[]>);
  }

  const { isLoading, isError, data, error } = useQuery<FoodItem[], Error>('foodItems', fetchFoodItems);

  if (mutation.isLoading) {
    return <div>Creating new food entry...</div>
  }

  if (isLoading) {
    return <div>Loading...</div>
  }

  if (isError) {
    return <div>Something went wrong: {error.message}</div>
  }

  return (
    <div className="form-container">
      <div>
        <label htmlFor="foodItem">Food Item</label>
        <select name="foodItem" id="foodItem" onChange={(e) => setFoodEntry({...foodEntry, ["foodItemId"]: e.target.value})}>
          {data?.map(foodItem => <option value={foodItem.id}>{foodItem.name}</option>)}
        </select>
      </div>
      <div>
        <label htmlFor="amount">Amount</label>
        <input
          id="amount"
          type="text"
          value={foodEntry.amount}
          onChange={(e) => setFoodEntry({...foodEntry, ["amount"]: parseInt(e.target.value)})}
        />
      </div>
      <div>
        <label htmlFor="date">Date</label>
        <input
          id="date"
          type="date"
          value={foodEntry.date}
          onChange={(e) => setFoodEntry({...foodEntry, ["date"]: e.target.value})}
        />
      </div>
      <div>
        <button onClick={handleCreate}>Add food</button>
      </div>
    </div>
  );
}
