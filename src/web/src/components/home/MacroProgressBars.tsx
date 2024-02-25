import { useAuth0 } from "@auth0/auth0-react";
import { Flex, Progress, Stack, Text } from "@mantine/core";
import { useQuery } from "react-query";
import { fetchDayFoodEntries } from "../../queries/FoodEntry";
import { fetchUserDetails } from "../../queries/UserDetails";

const MacroProgressBars = (props: { date: Date }) => {
  const { getAccessTokenSilently } = useAuth0();

  const { isLoading, isError, data, error } = useQuery<FoodEntry[], Error>(
    "fetchFoodEntries",
    async () => {
      const token = await getAccessTokenSilently();
      return fetchDayFoodEntries(token, props.date);
    }
  );

  const userDetailsData = useQuery<UserDetails, Error>(
    "userDetails",
    async () => {
      const token = await getAccessTokenSilently();
      return fetchUserDetails(token);
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

  const carbsProgressBar = userDetailsData.data?.carbs
    ? (carbs / userDetailsData.data.carbs) * 100
    : 0;

  const proteinProgressBar = userDetailsData.data?.protein
    ? (protein / userDetailsData.data.protein) * 100
    : 0;

  const fatProgressBar = userDetailsData.data?.fat
    ? (fat / userDetailsData.data.fat) * 100
    : 0;

  return (
    <Flex maw="100%" justify="center" gap="xl" wrap="nowrap">
      <Stack w="100" align="center">
        <Text>Carbs</Text>
        <Progress w="100%" value={carbsProgressBar} />
        <Text size="sm">
          {carbs}/{userDetailsData?.data?.carbs}g
        </Text>
      </Stack>
      <Stack w="100" align="center">
        <Text>Protein</Text>
        <Progress w="100%" value={proteinProgressBar} />
        <Text size="sm">
          {protein}/{userDetailsData?.data?.protein}g
        </Text>
      </Stack>
      <Stack w="100" align="center">
        <Text>Fat</Text>
        <Progress w="100%" value={fatProgressBar} />
        <Text size="sm">
          {fat}/{userDetailsData?.data?.fat}g
        </Text>
      </Stack>
    </Flex>
  );
};

export default MacroProgressBars;
