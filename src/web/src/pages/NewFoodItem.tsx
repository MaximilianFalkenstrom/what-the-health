import { useNavigate } from "react-router";
import { useMutation } from "react-query";
import { useAuth0 } from "@auth0/auth0-react";
import { useForm } from "@mantine/form";
import { Box, Button, Group, TextInput, Text, Stack } from "@mantine/core";

const baseUrl = import.meta.env.VITE_BACKEND_BASE_URL;

export default function NewFoodItem() {
  const { getAccessTokenSilently } = useAuth0();
  const navigate = useNavigate();

  const createFoodItem = async (newFoodItem: NewFoodItem) => {
    const token = await getAccessTokenSilently();

    if (!token) {
      throw new Error("Could not fetch token"); // TODO: Error handling
    }

    return await fetch(`${baseUrl}/api/fooditem`, {
      method: "POST",
      headers: {
        "content-type": "application/json",
        authorization: `Bearer ${token}`,
      },
      body: JSON.stringify(newFoodItem),
    });
  };

  const mutation = useMutation((newFoodItem: NewFoodItem) =>
    createFoodItem(newFoodItem)
  );

  const handleCreate = async (foodItem: NewFoodItem) => {
    const response = await mutation.mutateAsync(foodItem);

    if (response.ok) {
      const createdFoodItem: NewFoodItem = await response.json();

      if (createdFoodItem.id) {
        navigate(`/food/item/${createdFoodItem.id}`);
      }
    }
  };

  if (mutation.isLoading) {
    return <div>Creating new food item...</div>;
  }

  const form = useForm<NewFoodItem>({
    initialValues: {
      id: undefined,
      name: "",
      calories: undefined,
      carbohydrates: undefined,
      protein: undefined,
      fat: undefined,
    },
  });

  return (
    <Box maw={340} mx="auto">
      <form onSubmit={form.onSubmit(handleCreate)}>
        <Stack gap="md">
          <Text size="xl" fw={500}>
            Create new food item
          </Text>

          <TextInput
            withAsterisk
            label="Name"
            placeholder="Name"
            {...form.getInputProps("name")}
          />

          <TextInput
            withAsterisk
            label="Calories"
            placeholder="123"
            {...form.getInputProps("calories")}
          />

          <TextInput
            withAsterisk
            label="Carbs (g)"
            placeholder="12"
            {...form.getInputProps("carbs")}
          />

          <TextInput
            withAsterisk
            label="Protein (g)"
            placeholder="12"
            {...form.getInputProps("protein")}
          />

          <TextInput
            withAsterisk
            label="Fat (g)"
            placeholder="12"
            {...form.getInputProps("fat")}
          />

          <Group justify="flex-end" mt="md">
            <Button type="submit">Submit</Button>
          </Group>
        </Stack>
      </form>
    </Box>
  );
}
