import { Routes, Route } from "react-router";
import Home from "./pages/Home";
import NewFoodItem from "./pages/NewFoodItem";
import FoodItem from "./pages/FoodItem";
import { useAuth0, withAuthenticationRequired } from "@auth0/auth0-react";
import NewFoodEntry from "./pages/NewFoodEntry";
import FoodEntry from "./pages/FoodEntry";
import Navbar from "./components/Navbar";

const ProtectedAddFoodEntry = withAuthenticationRequired(NewFoodEntry);
const ProtectedFoodEntry = withAuthenticationRequired(FoodEntry);

const ProtectedAddFoodItem = withAuthenticationRequired(NewFoodItem);
const ProtectedFoodItem = withAuthenticationRequired(FoodItem);

function App() {
  const { isAuthenticated, isLoading } = useAuth0();
    
  if (isLoading) {
    return <div>Loading...</div>;
  }

  return (
    <>
      <Navbar isAuthenticated={isAuthenticated}>
        <Routes>
          <Route path="/" element={<Home />} />

          <Route path="/food/entry/new" element={<ProtectedAddFoodEntry />} />
          <Route path="/food/entry/:id" element={<ProtectedFoodEntry />} />

          <Route path="/food/item/new" element={<ProtectedAddFoodItem />} />
          <Route path="/food/item/:id" element={<ProtectedFoodItem />} />
        </Routes>
      </Navbar>
    </>
  );
}

export default App;
