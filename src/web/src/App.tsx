import { Routes, Route } from "react-router";
import Home from "./pages/Home";
import NewFoodItem from "./pages/NewFoodItem";
import FoodItem from "./pages/FoodItem";
import { useAuth0, withAuthenticationRequired } from "@auth0/auth0-react";
import NewFoodEntry from "./pages/NewFoodEntry";
import FoodEntry from "./pages/FoodEntry";

const ProtectedAddFoodEntry = withAuthenticationRequired(NewFoodEntry);
const ProtectedFoodEntry = withAuthenticationRequired(FoodEntry);

const ProtectedAddFoodItem = withAuthenticationRequired(NewFoodItem);
const ProtectedFoodItem = withAuthenticationRequired(FoodItem);

function App() {
  const { isLoading } = useAuth0();
    
  if (isLoading) {
    return <div>Loading...</div>;
  }

  return (
    <>
      <Routes>
        <Route path="/" element={<Home />} />

        <Route path="/food/entry/new" element={<ProtectedAddFoodEntry />} />
        <Route path="/food/entry/:id" element={<ProtectedFoodEntry />} />

        <Route path="/food/item/new" element={<ProtectedAddFoodItem />} />
        <Route path="/food/item/:id" element={<ProtectedFoodItem />} />
      </Routes>
    </>
  );
}

export default App;
