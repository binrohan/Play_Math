export interface Question {
    id: number;
    title: string;
    body: string;
    category: string;
    categoryId: number;
    postDate: Date;
    questioner: string;
    viewed: number;
    isSolved: boolean;
}
