import { Category } from './Category';

export interface Article {
    id: number;
    title: string;
    subTitle: string;
    category: Category;
    body: string;

    published: Date;
}
