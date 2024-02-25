const baseUrl = import.meta.env.VITE_BACKEND_BASE_URL;

export const fetchTodaysFoodEntries = async (
  token: string
): Promise<FoodEntry[]> => {
  if (!token) {
    throw new Error("Could not fetch token"); // TODO: Error handling
  }

  const date = new Date(Date.now()).toISOString().split("T")[0];

  return await fetch(`${baseUrl}/api/foodentry/date/${date}`, {
    method: "GET",
    headers: {
      "content-type": "application/json",
      authorization: `Bearer ${token}`,
    },
  }).then((res) => res.json() as Promise<FoodEntry[]>);
};

export const fetchDayFoodEntries = async (
  token: string,
  date: Date
): Promise<FoodEntry[]> => {
  if (!token) {
    throw new Error("Could not fetch token"); // TODO: Error handling
  }

  return await fetch(
    `${baseUrl}/api/foodentry/date/${date.toISOString().split("T")[0]}`,
    {
      method: "GET",
      headers: {
        "content-type": "application/json",
        authorization: `Bearer ${token}`,
      },
    }
  ).then((res) => res.json() as Promise<FoodEntry[]>);
};
