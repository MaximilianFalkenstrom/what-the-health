type CalorieCircleProps = {
  caloriesLeft: number;
};

export default function CalorieCircle({ caloriesLeft }: CalorieCircleProps) {
  return (
    <div className="calContainer">
      <div className="calorieProgressContainer">
        <div className="pieChartOuter">
          <div className="pieChartInner">
            <h2 className="calories">{caloriesLeft}</h2>
            <p>Kcal left</p>
          </div>
        </div>
        <svg>
          <circle cx="60" cy="60" r="55" strokeLinecap="round"></circle>
        </svg>
      </div>
    </div>
  );
}
