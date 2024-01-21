import { Routes, Route } from "react-router";
import Home from "./pages/Home";
import AddFoodItem from "./pages/AddFoodItem";
import FoodItem from "./pages/FoodItem";

function App() {
  return (
    <>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/food/new" element={<AddFoodItem />} />
        <Route path="/food/:id" element={<FoodItem />} />
      </Routes>
    </>
  );
}

export default App;
