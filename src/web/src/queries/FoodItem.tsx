import { BASE_URL } from "../utils/constants";

export const postFoodItem = async (
  foodItem: NewFoodItem,
  token: string
): Promise<Response> => {
  if (!token) {
    throw new Error("Could not fetch token"); // TODO: Error handling
  }

  return await fetch(`${BASE_URL}/api/fooditem`, {
    method: "POST",
    headers: {
      "content-type": "application/json",
      authorization: `Bearer ${token}`,
    },
    body: JSON.stringify(foodItem),
  });
};
