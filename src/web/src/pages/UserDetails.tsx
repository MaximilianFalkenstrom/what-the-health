import { useAuth0 } from "@auth0/auth0-react";
import {
  Box,
  Button,
  Group,
  TextInput,
  Text,
  Stack,
  NumberInput,
} from "@mantine/core";
import { DateInput, DatesProvider } from "@mantine/dates";
import { useForm } from "@mantine/form";
import { useEffect, useState } from "react";

import { useMutation } from "react-query";
import { useNavigate } from "react-router";

const baseUrl = import.meta.env.VITE_BACKEND_BASE_URL;

export default function UserDetails() {
  const { getAccessTokenSilently } = useAuth0();
  const navigate = useNavigate();

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

  const fetchInfo = async () => {
    const token = await getAccessTokenSilently();
    return fetch(`${baseUrl}/api/userdetails`, {
      headers: {
        "content-type": "application/json",
        authorization: `Bearer ${token}`,
      },
    })
      .then((response) => response.json())
      .then((responseData) => {
        form.setValues({
          name: responseData.name,
          calories: responseData.calories,
          birthday: responseData.birthday,
          height: responseData.height,
          weight: responseData.weight,
        });

        setIsNew(false);
        setDate(new Date(responseData.birthday));
      });
  };

  useEffect(() => {
    fetchInfo();
  });

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

  const mutation = useMutation((userDetails: UserDetails) =>
    saveUserDetails(userDetails)
  );

  const handleCreate = async (userDetails: UserDetails) => {
    const response = await mutation.mutateAsync(userDetails);

    if (response.ok) {
      navigate(`/`);
    }
  };

  if (mutation.isLoading) {
    return <div>Saving...</div>;
  }

  return (
    <Box maw={340} mx="auto">
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
                form.values.birthday = value?.toISOString().split("T")[0];
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
