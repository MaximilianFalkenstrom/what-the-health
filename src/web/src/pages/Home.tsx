import "./css/Home.css";
import AddFoodItemButton from "../components/AddFoodItemButton";
import CalorieCircle from "../components/CalorieCircle";
import LoginButton from "../components/LoginButton";
import { useAuth0 } from "@auth0/auth0-react";

function Home() {
  const { isAuthenticated } = useAuth0();
  
  if (!isAuthenticated) {
    return <div><LoginButton /></div>;
  }

  return (
    <>
      <div>
        <h1>What the Health</h1>
      </div>
      <CalorieCircle caloriesLeft={2000} caloriesTotal={3000} />
      <div className="nutritionsProgressContainer">
        <div className="nutritionsProgress">
          <div className="progressBar">
            <label htmlFor="file">Carbs</label>
            <progress id="file" max="100" value="65"></progress>
            <p>6/105g</p>
          </div>
          <div className="progressBar">
            <label htmlFor="file">Protein</label>
            <progress id="file" max="100" value="65"></progress>
            <p>3/105g</p>
          </div>
          <div className="progressBar">
            <label htmlFor="file">Fat</label>
            <progress id="file" max="100" value="65"></progress>
            <p>2/256g</p>
          </div>
        </div>
      </div>
      <AddFoodItemButton />
    </>
  );
}

export default Home;
