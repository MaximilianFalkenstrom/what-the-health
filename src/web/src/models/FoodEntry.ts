interface FoodEntry {
    id: string | undefined;
    foodItemId: string;
    foodItem: FoodItem | null;
    amount: number;
    date: string;
}