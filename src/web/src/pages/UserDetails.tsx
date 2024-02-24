import { useAuth0 } from "@auth0/auth0-react";
import {
  Box,
  Button,
  Group,
  TextInput,
  Text,
  Stack,
  NumberInput,
  LoadingOverlay,
} from "@mantine/core";
import { DateInput, DatesProvider } from "@mantine/dates";
import { useForm } from "@mantine/form";
import { notifications } from "@mantine/notifications";

import { useMutation, useQuery } from "react-query";
import { fetchUserDetails } from "../queries/UserDetails";
import { useState } from "react";
import { IconCheck, IconX } from "@tabler/icons-react";

const baseUrl = import.meta.env.VITE_BACKEND_BASE_URL;

export default function UserDetails() {
  const { getAccessTokenSilently } = useAuth0();

  const [isNew, setIsNew] = useState<boolean>(true);
  const [date, setDate] = useState<Date | null>(null);

  const form = useForm<UserDetails>({
    initialValues: {
      name: "",
      birthday: undefined,
      height: 0,
      weight: 0,
      calories: 0,
    },
  });

  const userDetails = useQuery<UserDetails, Error>(
    "userDetails",
    async () => {
      const token = await getAccessTokenSilently();
      return fetchUserDetails(token);
    },
    {
      refetchOnReconnect: false,
      refetchOnWindowFocus: false,
      onSuccess: (data: UserDetails) => {
        form.setValues({
          name: data.name,
          calories: data.calories,
          birthday: data.birthday,
          height: data.height,
          weight: data.weight,
        });

        setIsNew(false);
        setDate(new Date(Date.parse(data.birthday ?? "")));
      },
    }
  );

  const saveUserDetails = async (userDetails: UserDetails) => {
    const token = await getAccessTokenSilently();

    if (!token) {
      throw new Error("Could not fetch token"); // TODO: Error handling
    }

    if (isNew) {
      return await fetch(`${baseUrl}/api/userdetails`, {
        method: "POST",
        headers: {
          "content-type": "application/json",
          authorization: `Bearer ${token}`,
        },
        body: JSON.stringify(userDetails),
      });
    }

    return await fetch(`${baseUrl}/api/userdetails`, {
      method: "PATCH",
      headers: {
        "content-type": "application/json",
        authorization: `Bearer ${token}`,
      },
      body: JSON.stringify(userDetails),
    });
  };

  const mutation = useMutation(
    (userDetails: UserDetails) => saveUserDetails(userDetails),
    {
      onError: async () =>
        notifications.show({
          color: "red",
          icon: <IconX />,
          title: "Error",
          message:
            "Your user settings could not be saved at this time. Please try again.",
        }),
      onSuccess: async () =>
        notifications.show({
          color: "teal",
          icon: <IconCheck />,
          title: "Saved",
          message: "Your user settings were successfully saved.",
        }),
    }
  );

  const handleCreate = async (userDetails: UserDetails) =>
    await mutation.mutateAsync(userDetails);

  return (
    <Box maw={340} mx="auto">
      <LoadingOverlay
        visible={mutation.isLoading || userDetails.isLoading}
        zIndex={1000}
        overlayProps={{ radius: "sm", blur: 2 }}
      />
      <form onSubmit={form.onSubmit(handleCreate)}>
        <Stack gap="md">
          <Text size="xl" fw={500}>
            User Details
          </Text>

          <TextInput
            withAsterisk
            label="Name"
            placeholder="Name"
            {...form.getInputProps("name")}
          />

          <DatesProvider settings={{ timezone: "UTC" }}>
            <DateInput
              withAsterisk
              label="Birthday"
              placeholder="Birthday"
              valueFormat="YYYY-MM-DD"
              value={date}
              onChange={(value) => {
                setDate(value);
                form.setFieldValue(
                  "birthday",
                  value?.toISOString().split("T")[0]
                );
              }}
            />
          </DatesProvider>

          <NumberInput
            withAsterisk
            label="Calories"
            placeholder="0"
            {...form.getInputProps("calories")}
          />

          <NumberInput
            withAsterisk
            label="Height"
            placeholder="0"
            {...form.getInputProps("height")}
          />

          <NumberInput
            withAsterisk
            label="Weight"
            placeholder="0"
            {...form.getInputProps("weight")}
          />

          <Group justify="flex-end" mt="md">
            <Button type="submit">Save</Button>
          </Group>
        </Stack>
      </form>
    </Box>
  );
}
