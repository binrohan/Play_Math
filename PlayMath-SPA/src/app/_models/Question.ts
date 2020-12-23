import { Category } from "./Category";

export interface Question {
    id: number;
    title: string;
    body: string;
    categoryName: string;
    categoryId: number;
    postDate: Date;
    questioner: string;
    viewed: number;
    isSolved: boolean;
    category: Category;
    answerCount: number;
}
