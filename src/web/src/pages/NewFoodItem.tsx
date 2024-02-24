import { useNavigate } from "react-router";
import { useMutation } from "react-query";
import { useAuth0 } from "@auth0/auth0-react";
import { useForm, zodResolver } from "@mantine/form";
import {
  Box,
  Button,
  Group,
  TextInput,
  Text,
  Stack,
  LoadingOverlay,
  NumberInput,
} from "@mantine/core";
import { postFoodItem } from "../queries/FoodItem";
import { notifications } from "@mantine/notifications";
import { IconX, IconCheck } from "@tabler/icons-react";
import { foodItemValidationSchema } from "../validation/FoodItem";

export default function NewFoodItem() {
  const { getAccessTokenSilently } = useAuth0();
  const navigate = useNavigate();

  const createFoodItem = async (
    newFoodItem: NewFoodItem
  ): Promise<Response> => {
    const token = await getAccessTokenSilently();

    return await postFoodItem(newFoodItem, token);
  };

  const mutation = useMutation(
    (newFoodItem: NewFoodItem) => createFoodItem(newFoodItem),
    {
      onError: async () =>
        notifications.show({
          color: "red",
          icon: <IconX />,
          title: "Error",
          message:
            "Food item could not be created at this time. Please try again.",
        }),
      onSuccess: async () =>
        notifications.show({
          color: "teal",
          icon: <IconCheck />,
          title: "Saved",
          message: "Your food item was successfully saved.",
        }),
    }
  );

  const handleCreate = async (foodItem: NewFoodItem) => {
    const response = await mutation.mutateAsync(foodItem);

    if (!response.ok) {
      return;
    }

    const createdFoodItem = await (response.json() as Promise<FoodItem>);

    if (createdFoodItem.id) {
      navigate(-1);
    }
  };

  const form = useForm<NewFoodItem>({
    validateInputOnChange: true,
    validate: zodResolver(foodItemValidationSchema),
    initialValues: {
      name: "",
      calories: undefined,
      carbohydrates: undefined,
      protein: undefined,
      fat: undefined,
    },
  });

  return (
    <Box maw={340} mx="auto">
      <LoadingOverlay
        visible={mutation.isLoading}
        zIndex={1000}
        overlayProps={{ radius: "sm", blur: 2 }}
      />
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

          <NumberInput
            withAsterisk
            label="Calories"
            placeholder="0"
            {...form.getInputProps("calories")}
          />

          <NumberInput
            withAsterisk
            label="Carbs (g)"
            placeholder="0"
            {...form.getInputProps("carbs")}
          />

          <NumberInput
            withAsterisk
            label="Protein (g)"
            placeholder="0"
            {...form.getInputProps("protein")}
          />

          <NumberInput
            withAsterisk
            label="Fat (g)"
            placeholder="0"
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
