interface FoodEntry {
    id: string | undefined;
    foodItemId: string;
    mealTypeId: string;
    foodItem: FoodItem | null;
    mealType: MealType | null;
    amount: number;
    date: string;
}