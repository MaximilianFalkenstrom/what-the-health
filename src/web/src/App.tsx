import "./App.css";
import CalorieCircle from "./components/CalorieCircle";

function App() {
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
    </>
  );
}

export default App;
