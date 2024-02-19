import { useAuth0 } from "@auth0/auth0-react";
import { Flex, Progress, Stack, Text } from "@mantine/core";
import { useQuery } from "react-query";
import { fetchTodaysFoodEntries } from "../../queries/FoodEntry";

const MacroProgressBars = () => {
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

  const carbs =
    data
      ?.map((foodEntry) =>
        foodEntry.foodItem
          ? foodEntry.foodItem?.carbohydrates * foodEntry.amount
          : 0
      )
      .reduce((acc, curr) => acc + curr, 0) ?? 0;

  const fat =
    data
      ?.map((foodEntry) =>
        foodEntry.foodItem ? foodEntry.foodItem?.fat * foodEntry.amount : 0
      )
      .reduce((acc, curr) => acc + curr, 0) ?? 0;

  const protein =
    data
      ?.map((foodEntry) =>
        foodEntry.foodItem ? foodEntry.foodItem?.protein * foodEntry.amount : 0
      )
      .reduce((acc, curr) => acc + curr, 0) ?? 0;

  return (
    <Flex maw="100%" justify="center" gap="xl" wrap="nowrap">
      <Stack w="100" align="center">
        <Text>Carbs</Text>
        <Progress w="100%" value={(carbs / 105) * 100} />
        <Text size="sm">{carbs}/105g</Text>
      </Stack>
      <Stack w="100" align="center">
        <Text>Protein</Text>
        <Progress w="100%" value={(protein / 121) * 100} />
        <Text size="sm">{protein}/121g</Text>
      </Stack>
      <Stack w="100" align="center">
        <Text>Fat</Text>
        <Progress w="100%" value={(fat / 256) * 100} />
        <Text size="sm">{fat}/256g</Text>
      </Stack>
    </Flex>
  );
};

export default MacroProgressBars;
