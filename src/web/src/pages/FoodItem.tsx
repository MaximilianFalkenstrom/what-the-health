import { useAuth0 } from "@auth0/auth0-react";
import { useQuery } from "react-query";
import { useParams } from "react-router";

const baseUrl = import.meta.env.VITE_BACKEND_BASE_URL;

export default function FoodItem() {
  const { id } = useParams();

  const { getAccessTokenSilently } = useAuth0();

  const fetchFoodItem = async (): Promise<FoodItem> => {
    const token = await getAccessTokenSilently();

    if (!token) {
      throw new Error("Could not fetch token"); // TODO: Error handling
    }

    return await fetch(`${baseUrl}/api/fooditem/${id}`, {
      method: 'GET',
      headers: {
        "content-type": "application/json",
        authorization: `Bearer ${token}`,
      },
    }).then(res => res.json() as Promise<FoodItem>);
  }

  const { isLoading, isError, data, error } = useQuery<FoodItem, Error>('foodItem', fetchFoodItem);

  if (isLoading) {
    return <div>Loading...</div>
  }

  if (isError) {
    return <div>Something went wrong: {error.message}</div>
  }

  return (
    <div>
      <div>Id: {data?.id}</div>
      <div>Name: {data?.name}</div>
      <div>Calories: {data?.calories}</div>
      <div>Carbohydrates: {data?.carbohydrates}</div>
      <div>Fat: {data?.fat}</div>
      <div>Protein: {data?.protein}</div>
    </div>);
}
