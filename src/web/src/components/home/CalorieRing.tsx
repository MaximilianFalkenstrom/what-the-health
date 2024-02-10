import { useAuth0 } from "@auth0/auth0-react";
import { Center, Divider, RingProgress, Stack, Text } from "@mantine/core";
import { useQuery } from "react-query";
import { fetchTodaysFoodEntries } from "../../queries/FoodEntry";

const CalorieRing = () => {
  const { getAccessTokenSilently } = useAuth0();

  const { isLoading, isError, data, error } = useQuery<FoodEntry[], Error>(
    "fetchFoodEntries",
    async () => {
      const token = await getAccessTokenSilently();
      return fetchTodaysFoodEntries(token);
    }
  );

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>Something went wrong: {error.message}</div>;
  }

  const consumedCalories =
    data
      ?.map((foodEntry) =>
        foodEntry.foodItem ? foodEntry.foodItem?.calories * foodEntry.amount : 0
      )
      .reduce((acc, curr) => acc + curr, 0) ?? 0;

  return (
    <Center>
      <RingProgress
        size={180}
        thickness={12}
        roundCaps
        label={
          <Stack justify="center" align="center" gap="xs">
            <Text size="xl" fw={500} ta="center">
              {consumedCalories}
            </Text>
            <Divider w="50" size="sm" />
            <Text size="md" fw={500} ta="center">
              2000
            </Text>
          </Stack>
        }
        sections={[{ value: 40, color: "cyan" }]}
      />
    </Center>
  );
};

export default CalorieRing;
