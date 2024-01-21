type CalorieCircleProps = {
  caloriesLeft: number;
  caloriesTotal: number;
};

export default function CalorieCircle({
  caloriesLeft,
  caloriesTotal,
}: CalorieCircleProps) {
  const circleFullness: number = 360 - 360 * (caloriesLeft / caloriesTotal);
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
          <circle
            cx="60"
            cy="60"
            r="57"
            strokeLinecap="round"
            key={circleFullness}
            style={
              {
                "--circleFullness": circleFullness,
              } as React.CSSProperties
            }
          ></circle>
        </svg>
      </div>
    </div>
  );
}
