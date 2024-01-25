import { Routes, Route } from "react-router";
import Home from "./pages/Home";
import AddFoodItem from "./pages/AddFoodItem";
import FoodItem from "./pages/FoodItem";
import { useAuth0, withAuthenticationRequired } from "@auth0/auth0-react";

const ProtectedAddFoodItem = withAuthenticationRequired(AddFoodItem);
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

        <Route path="/food/new" element={<ProtectedAddFoodItem />} />
        <Route path="/food/:id" element={<ProtectedFoodItem />} />
      </Routes>
    </>
  );
}

export default App;
