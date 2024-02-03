import { useAuth0 } from "@auth0/auth0-react";
import { useQuery } from "react-query";
import { useParams } from "react-router";

const baseUrl = import.meta.env.VITE_BACKEND_BASE_URL;

export default function FoodEntry() {
  const { id } = useParams();

  const { getAccessTokenSilently } = useAuth0();

  const fetchFoodEntry = async (): Promise<FoodEntry> => {
    const token = await getAccessTokenSilently();

    if (!token) {
      throw new Error("Could not fetch token"); // TODO: Error handling
    }

    return await fetch(`${baseUrl}/api/foodentry/${id}`, {
      method: 'GET',
      headers: {
        "content-type": "application/json",
        authorization: `Bearer ${token}`,
      },
    }).then(res => res.json() as Promise<FoodEntry>);
  }

  const { isLoading, isError, data, error } = useQuery<FoodEntry, Error>('foodEntry', fetchFoodEntry);

  if (isLoading) {
    return <div>Loading...</div>
  }

  if (isError) {
    return <div>Something went wrong: {error.message}</div>
  }
  
  if (!data || !data.foodItem) {
    return <div>Could not fetch entry</div>
  }

  return (
    <div>
      <div>Id: {data.id}</div>
      <div>Name: {data.foodItem.name}</div>
      <div>Amount: {data.amount}</div>
      
      <div>Calories per unit: {data.foodItem.calories}</div>
      <div>Carbohydrates per unit: {data.foodItem.carbohydrates}</div>
      <div>Fat per unit: {data.foodItem.fat}</div>
      <div>Protein per unit: {data.foodItem.protein}</div>

      <div>Total calories: {data.foodItem.calories * data.amount}</div>
      <div>Carbohydrates: {data.foodItem.carbohydrates * data.amount}</div>
      <div>Fat: {data.foodItem.fat * data.amount}</div>
      <div>Protein: {data.foodItem.protein * data.amount}</div>
    </div>);
}
