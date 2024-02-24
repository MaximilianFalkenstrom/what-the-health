import { z } from 'zod';

export const foodItemValidationSchema = z.object({
    name: z
        .string()
        .min(2, { message: 'Name should have at least 2 letters' })
        .max(255, { message: 'Name should have less than 255 letters' }),
    calories: z.number().min(0, { message: 'A food item must have at least  0 calories' }).max(1000, { message: 'A food item may not have more than 1000 calories' }),
    carbs: z
        .number()
        .min(0, { message: 'A food item must have at least 0 grams of carbs' })
        .max(100, { message: 'A food item may not have more than 100 grams of carbs' }),
    protein: z
        .number()
        .min(0, { message: 'A food item must have at least 0 grams of protein' })
        .max(100, { message: 'A food item may not have more than 100 grams of protein' }),
    fat: z
        .number()
        .min(0, { message: 'A food item must have at least 0 grams of fat' })
        .max(100, { message: 'A food item may not have more than 100 grams of fat' }),
});