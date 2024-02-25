import NewFoodItemButton from "../components/NewFoodItemButton";
import LoginButton from "../components/LoginButton";
import { useAuth0 } from "@auth0/auth0-react";
import NewFoodEntryButton from "../components/NewFoodEntryButton";
import { Center, Container, Stack } from "@mantine/core";
import DateSelector from "../components/home/DateSelector";

function Home() {
  const { isAuthenticated } = useAuth0();

  if (!isAuthenticated) {
    return (
      <Center h="100vh" bg="var(--mantine-color-gray-light)">
        <LoginButton />
      </Center>
    );
  }

  return (
    <>
      <Container>
        <Center>
          <DateSelector />
        </Center>
        <Stack py="md">
          <NewFoodItemButton />
          <NewFoodEntryButton />
        </Stack>
      </Container>
    </>
  );
}

export default Home;
