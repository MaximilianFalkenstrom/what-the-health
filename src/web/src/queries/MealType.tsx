const baseUrl = import.meta.env.VITE_BACKEND_BASE_URL;

export const fetchMealTypes = async (token: string): Promise<MealType[]> => {
  if (!token) {
    throw new Error("Could not fetch token"); // TODO: Error handling
  }

  return await fetch(`${baseUrl}/api/mealtype`, {
    method: "GET",
    headers: {
      "content-type": "application/json",
      authorization: `Bearer ${token}`,
    },
  }).then((res) => res.json() as Promise<MealType[]>);
};
