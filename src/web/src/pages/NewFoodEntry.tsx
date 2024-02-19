import { useNavigate } from "react-router";
import { useMutation, useQuery } from "react-query";
import { useAuth0 } from "@auth0/auth0-react";
import {
  Box,
  Button,
  ComboboxItem,
  Group,
  NumberInput,
  Select,
  Stack,
  Text,
} from "@mantine/core";
import { DateInput, DatesProvider } from "@mantine/dates";
import { useForm } from "@mantine/form";
import { useState } from "react";

const baseUrl = import.meta.env.VITE_BACKEND_BASE_URL;

export default function NewFoodEntry() {
  const { getAccessTokenSilently } = useAuth0();
  const navigate = useNavigate();

  const createFoodEntry = async (newFoodEntry: NewFoodEntry) => {
    const token = await getAccessTokenSilently();

    if (!token) {
      throw new Error("Could not fetch token"); // TODO: Error handling
    }

    return await fetch(`${baseUrl}/api/foodentry`, {
      method: "POST",
      headers: {
        "content-type": "application/json",
        authorization: `Bearer ${token}`,
      },
      body: JSON.stringify(newFoodEntry),
    });
  };

  const mutation = useMutation((newFoodEntry: NewFoodEntry) =>
    createFoodEntry(newFoodEntry)
  );

  const handleCreate = async (newFoodEntry: NewFoodEntry) => {
    console.log(newFoodEntry.date);

    const response = await mutation.mutateAsync(newFoodEntry);

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
      method: "GET",
      headers: {
        "content-type": "application/json",
        authorization: `Bearer ${token}`,
      },
    }).then((res) => res.json() as Promise<FoodItem[]>);
  };

  const { isLoading, isError, data, error } = useQuery<FoodItem[], Error>(
    "foodItems",
    fetchFoodItems
  );

  const form = useForm<NewFoodEntry>({
    initialValues: {
      foodItemId: undefined,
      amount: 1,
      date: undefined,
    },
  });

  const [foodItem, setFoodItem] = useState<ComboboxItem | null>(null);
  const [date, setDate] = useState<Date | null>();

  if (mutation.isLoading) {
    return <div>Creating new food entry...</div>;
  }

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>Something went wrong: {error.message}</div>;
  }

  return (
    <Box maw={340} mx="auto">
      <form onSubmit={form.onSubmit(handleCreate)}>
        <Stack gap="md">
          <Text size="xl" fw={500}>
            Log food
          </Text>

          <Select
            label="Food item"
            placeholder="Pick value"
            data={data?.map((value) => {
              return { value: value.id, label: value.name };
            })}
            value={foodItem ? foodItem.value : null}
            onChange={(_value, option) => {
              setFoodItem(option);
              form.values.foodItemId = option.value;
            }}
            searchable
          />

          <NumberInput
            label="Amount"
            placeholder="1"
            {...form.getInputProps("amount")}
          />

          <DatesProvider settings={{ timezone: "UTC" }}>
            <DateInput
              label="Date"
              placeholder="Pick a date"
              value={date}
              onChange={(value) => {
                setDate(value);
                form.values.date = value?.toISOString().split("T")[0];
              }}
            />
          </DatesProvider>

          <Group justify="flex-end" mt="md">
            <Button type="submit">Submit</Button>
          </Group>
        </Stack>
      </form>
    </Box>
  );
}
