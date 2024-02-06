import "./css/Home.css";
import NewFoodItemButton from "../components/NewFoodItemButton";
import LoginButton from "../components/LoginButton";
import { useAuth0 } from "@auth0/auth0-react";
import NewFoodEntryButton from "../components/NewFoodEntryButton";
import { Center, Container, Divider, Flex, Progress, RingProgress, Stack, Text } from "@mantine/core";

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
        <div>
          <h1>What the Health</h1>
        </div>
        <Center>
          <RingProgress
            size={180}
            thickness={12}
            roundCaps
            label={
              <Stack justify="center" align="center">
                <Text size="xl" fw={500} ta="center">1360</Text>
                <Divider w="50" size="sm" />
                <Text size="md" fw={500} ta="center">2000</Text>
              </Stack>
            }
            sections={[{ value: 40, color: 'cyan' }]}
          />
        </Center>
        <Flex maw="100%" justify="space-around" wrap="nowrap">
          <Stack w="100" align="center">
            <Text>Carbs</Text>
            <Progress w="100%" value={35} />
            <Text size="sm">6/105g</Text>
          </Stack>
          <Stack w="100" align="center">
            <Text>Protein</Text>
            <Progress w="100%" value={85} />
            <Text size="sm">56/121g</Text>
          </Stack>
          <Stack w="100" align="center">
            <Text>Fat</Text>
            <Progress w="100%" value={55} />
            <Text size="sm">2/256g</Text>
          </Stack>
        </Flex>
        <Stack py="md">
          <NewFoodItemButton />
          <NewFoodEntryButton />
        </Stack>
      </Container>
    </>
  );
}

export default Home;
